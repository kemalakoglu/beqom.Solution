## beqom.Solution
beqom.Solution .Net 6.x support !

## IoC
ASP.NET Core Dependency 

## Principles
SOLID <br/>
Domain Driven Design

## Object Mappers
AutoMapper

## Log
Serilog support
Elasticsearch
Kibana

## Documentation
Swagger
https://localhost:44364/swagger/index.html

## CQRS
Mediatr

## Benefits
 - Conventional Dependency Registering
 - Async await first 
 - GlobalQuery Filtering
 - Domain Driven Design Concepts
 - Repository pattern implementations
 - Object to object mapping with abstraction
 - Net 6.x support
 - Simple Usage
 - Modularity
 - Event Sourcing
 - Generic and Intigrated Response provider
 - CQRS usage
 - Custom Exception
 - Dockerized API
 
   

***Basic Usage***

        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
               Host.CreateDefaultBuilder(args)
                   .ConfigureWebHostDefaults(webBuilder =>
                   {
                       webBuilder.UseContentRoot(Directory.GetCurrentDirectory());
                       webBuilder.UseIISIntegration();
                       webBuilder.UseStartup<Startup>();
                   });
                         
***Conventional Registration***	 	

       public static class DependencyInjection
    {
        public static void ConfigureMediatr(this IServiceCollection services)
        {
            services.AddMediatR(typeof(OptionServiceHandler).GetTypeInfo().Assembly);
        }

        public static void ConfigureRepositories(this IServiceCollection services)
        {
            services.AddScoped<IOptionRepository, OptionRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IReportRepository, ReportRepository>();
        }

        public static void ConfigureApplicationService(this IServiceCollection services)
        {
            services.AddScoped<IApplicationService, ApplicationService>();
        }
    }
                             ...
                         })

  
***AutoMapper Activation***

	 services.AddAutoMapper();
	 
***Swagger Activation***

	 services.ConfigureSwagger();


***Serilog Activation***
 

         Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .Enrich.WithProperty("Application", "app")
                .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                .MinimumLevel.Override("System", LogEventLevel.Warning)
                //.WriteTo.File(new JsonFormatter(), "log.json")
                //.ReadFrom.Configuration(configuration)
                .WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri("localhost:9200"))
                {
                    AutoRegisterTemplate = true,
                    AutoRegisterTemplateVersion = AutoRegisterTemplateVersion.ESv6,
                    FailureCallback = e => Console.WriteLine("fail message: " + e.MessageTemplate),
                    EmitEventFailure = EmitEventFailureHandling.WriteToSelfLog |
                                       EmitEventFailureHandling.WriteToFailureSink |
                                       EmitEventFailureHandling.RaiseCallback,
                    FailureSink = new FileSink("log" + ".json", new JsonFormatter(), null)
                })
                .MinimumLevel.Verbose()
                .CreateLogger();
            Log.Information("WebApi Starting...");
		
		

***Middleware Activation***

     public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context /* other dependencies */)
        {
            try
            {
                Log.Write(LogEventLevel.Information, "Service path is:" + context.Request.Path.Value,
                    context.Request.Body);
                await next(context);
            }
            catch (HttpRequestException ex)
            {
                Log.Write(LogEventLevel.Error, ex.Message, "Service path is:" + context.Request.Path.Value, ex);
                await HandleExceptionAsync(context, ex);
            }
            catch (AuthenticationException ex)
            {
                Log.Write(LogEventLevel.Error, ex.Message, "Service path is:" + context.Request.Path.Value, ex);
                await HandleExceptionAsync(context, ex);
            }
            catch (BusinessException ex)
            {
                Log.Write(LogEventLevel.Error, ex.Message, "Service path is:" + context.Request.Path.Value, ex);
                await HandleExceptionAsync(context, ex);
            }
            catch (Exception ex)
            {
                Log.Write(LogEventLevel.Error, ex.Message, ex.Source, ex.TargetSite, ex);
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, object exception)
        {
            var code = HttpStatusCode.InternalServerError; // 500 if unexpected
            var message = string.Empty;
            var RC = string.Empty;

            if (exception.GetType() == typeof(HttpRequestException))
            {
                code = HttpStatusCode.NotFound;
                RC = ResponseCodes.NotFound;
                message = BusinessException.GetDescription(RC);
            }
            else if (exception.GetType() == typeof(AuthenticationException))
            {
                code = HttpStatusCode.Unauthorized;
                RC = ResponseCodes.Unauthorized;
                message = BusinessException.GetDescription(RC);
            }
            else if (exception.GetType() == typeof(BusinessException))
            {
                var businesException = (BusinessException)exception;
                message = BusinessException.GetDescription(businesException.RC);
                code = HttpStatusCode.InternalServerError;
                RC = businesException.RC;
            }
            else if (exception.GetType() == typeof(Exception))
            {
                code = HttpStatusCode.BadRequest;
                RC = ResponseCodes.BadRequest;
                message = BusinessException.GetDescription(RC);
            }

            var response = new ErrorDTO
            {
                Message = message,
                RC = RC
            };
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            return context.Response.WriteAsync(JsonConvert.SerializeObject(response));
        }
    }
	
	
        
***Application Service definitions***

    / public partial class ApplicationService : IApplicationService
    {
        private readonly IMediator mediator;
        public ApplicationService(IMediator mediator)
        {
            this.mediator = mediator;
        }
		
		public async Task<IEnumerable<ReportResponseDto>> GetReportsAsync(ReportRequestDto request)
        {
            return await this.mediator.Send(request);
        }
		
		public async Task<OptionResponseDto> GetOptionAsync(OptionRequestDto request)
        {
            return await this.mediator.Send(request);
        }
    }
	
	
***QueryHandlers definitions***

	public class OptionServiceHandler: IRequestHandler<OptionRequestDto, OptionResponseDto>
    {
        private readonly IMapper mapper;
        private readonly IOptionRepository optionRepository;
        public OptionServiceHandler(IMapper mapper, IOptionRepository optionRepository)
        {
            this.mapper = mapper;
            this.optionRepository = optionRepository;
        }

        public async Task<OptionResponseDto> Handle(OptionRequestDto request, CancellationToken cancellationToken)
        {
            var response = new OptionResponseDto();
            Option option = await this.optionRepository.GetOptionAsync(request.Option);
            response = mapper.Map<OptionResponseDto>(option);
            return response;

        }
    }
	
	public class ReportServiceHandler : IRequestHandler<ReportRequestDto, IEnumerable<ReportResponseDto>>
    {
        private readonly IMapper mapper;
        private readonly IReportRepository reportRepository;
        public ReportServiceHandler(IMapper mapper, IReportRepository reportRepository)
        {
            this.mapper = mapper;
            this.reportRepository = reportRepository;
        }

        public async Task<IEnumerable<ReportResponseDto>> Handle(ReportRequestDto request, CancellationToken cancellationToken)
        {
            IEnumerable<ReportResponseDto> response = new List<ReportResponseDto>();
            IEnumerable<Report> report = await this.reportRepository.GetReportAsync();
            response = mapper.Map<IEnumerable<ReportResponseDto>>(report);
            return response;
        }
    }
     

***Log and Response Service definitions***
 public static class CreateResponse<T> where T : class
    {
        public static ResponseDTO<T> Return(T entity, string methodName)
        {

            string message = string.Empty;
            if (entity != null)
                message = GetDescription(ResponseCodes.Success);
            else
                message = GetDescription(ResponseCodes.NotFound);
            ResponseDTO<T> response = new ResponseDTO<T>
            {
                Data = entity,
                Message = message,
                Information = new Information
                {
                    TrackId = Guid.NewGuid().ToString()
                },
                RC = entity == null ? ResponseCodes.NotFound : ResponseCodes.Success
            };
            Log.Write(LogEventLevel.Information, message, response);
            return response;
        }

        public static ResponseListDTO<T> Return(IEnumerable<T> entity, string methodName)
        {
            string message = string.Empty;
            if (entity.Count() > 0)
                message = GetDescription(ResponseCodes.Success);
            else
                message = GetDescription(ResponseCodes.NotFound);

            ResponseListDTO<T> response = new ResponseListDTO<T>
            {
                Data = entity,
                Message = message,
                Information = new Information
                {
                    TrackId = Guid.NewGuid().ToString()
                },
                RC = entity == null ? ResponseCodes.NotFound : ResponseCodes.Success
            };
            Log.Write(LogEventLevel.Information, message, response);
            return response;
        }
        public static IConfiguration GetConfiguration()
        {
            return new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true).Build();
        }
        public static string GetDescription(string RC)
        {
            IConfiguration config = GetConfiguration();
            return config.GetSection("ResponseCodes:" + RC).Get<string>();
        }
    }
