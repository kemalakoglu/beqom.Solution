## beqom.Solution
Core.Infrastructure .Net 6.x support !

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

## CQRS
Mediatr

## Benefits
 - Conventional Dependency Registering
 - Async await first 
 - GlobalQuery Filtering
 - Domain Driven Design Concepts
 - Repository and UnitofWork pattern implementations
 - Object to object mapping with abstraction
 - Net 6.x support
 - Aspect Oriented Programming
 - Simple Usage
 - Modularity
 - Event Sourcing
 
   

***Basic Usage***

     WebHost.CreateDefaultBuilder(args)
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>();
                         
***Conventional Registration***	 	

      services.AddScoped<IUserStoreService, UserStoreService>();
                             ...
                         })

  
***AutoMapper Activation***

	 services.AddAutoMapper();
	 
***Swagger Activation***

	 services.ConfigureSwagger();


***Serilog Activation***
 

        services.ConfigureLogger(Configuration);
		
		 Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .Enrich.WithProperty("Application", "Core.Infrastructure.Presentation.API")
                .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                .MinimumLevel.Override("System", LogEventLevel.Warning)
                //.WriteTo.File(new JsonFormatter(), "log.json")
                //.ReadFrom.Configuration(configuration)
                .WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri("http://localhost:9200"))
                {
                    AutoRegisterTemplate = true,
                    AutoRegisterTemplateVersion = AutoRegisterTemplateVersion.ESv6,
                    FailureCallback = e => Console.WriteLine("Unable to submit event " + e.MessageTemplate),
                    EmitEventFailure = EmitEventFailureHandling.WriteToSelfLog |
                                       EmitEventFailureHandling.WriteToFailureSink |
                                       EmitEventFailureHandling.RaiseCallback,
                    FailureSink = new FileSink("log.json", new JsonFormatter(), null)
                })
                .MinimumLevel.Verbose()
                .CreateLogger();
            Log.Information("WebApi is Starting...");
		
		

***Interceptors Activation***

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
                RC = ResponseMessage.NotFound;
                message = BusinessException.GetDescription(RC);
            }
            else if (exception.GetType() == typeof(AuthenticationException))
            {
                code = HttpStatusCode.Unauthorized;
                RC = ResponseMessage.Unauthorized;
                message = BusinessException.GetDescription(RC);
            }
            else if (exception.GetType() == typeof(BusinessException))
            {
                var businesException = (BusinessException) exception;
                message = BusinessException.GetDescription(businesException.RC, businesException.param1);
                code = HttpStatusCode.InternalServerError;
                RC = businesException.RC;
            }
            else if (exception.GetType() == typeof(Exception))
            {
                code = HttpStatusCode.BadRequest;
                RC = ResponseMessage.BadRequest;
                message = BusinessException.GetDescription(RC);
            }

            var response = new Error
            {
                Message = message,
                RC = RC
            };
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int) code;
            return context.Response.WriteAsync(JsonConvert.SerializeObject(response));
        }
	
	
        
***Application Service definitions***

    // Query methods all comes from base class. You can override if you want!
     public class RefTypeService : IRefTypeService
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public RefTypeService(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }
		
		....
	}
	
    // CRUD methods all comes from base class. You can override if you want!
     public class RefTypeService : IRefTypeService
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public RefTypeService(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }
		
		....
	}
	
	
***CommandHandlers definitions***

     /// <summary>
        /// To filter Operations
        /// </summary>
        /// <param name="pFilter">filter exp. : <code>.Filter(x=>x.EntityProperty != null)</code></param>
        /// <returns>Added filter functionality to RepositoryQueryHelper Class</returns>
        IRepositoryQueryHelper<T> Filter(Expression<Func<T, bool>> pFilter);
        /// <summary>
        /// To Order Operations
        /// </summary>
        /// <param name="orderBy">Order Exp. <code>.OrderBy(x => x.OrderBy(y => y.EntityProperty).ThenBy(z => z.EntityProperty2))</code></param>
        /// <returns>Added filter functionality to RepositoryQueryHelper Class</returns>
        IRepositoryQueryHelper<T> OrderBy(Func<IQueryable<T>, IOrderedQueryable<T>> orderBy);
        /// <summary>
        /// To GroupBy Operations
        /// </summary>
        /// <param name="groupBy">GroupBy Operations <code>.OrderBy(x => x.OrderBy(y => y.EntityProperty).ThenBy(z => z.EntityProperty2))</code></param>
        /// <returns>Added GroupBy functionality to RepositoryQueryHelper Class</returns>
        IRepositoryQueryHelper<T> GroupBy(Func<IQueryable<T>, IGrouping<int, GroupCountResult>> groupBy);
        /// <summary>
        /// To Include Operations (Set Included Tables Data)
        /// </summary>
        /// <param name="expression">Include Exp. <code>.Include(x=>x.EntityName)</code></param>
        /// <returns>Added Include functionality to RepositoryQueryHelper Class</returns>
        IRepositoryQueryHelper<T> Include(Expression<Func<T, object>> expression);
        /// <summary>
        /// To paging by filtered, ordered and included or not
        /// </summary>
        /// <param name="pPage">Page Number</param>
        /// <param name="pPageSize">Data number</param>
        /// <param name="totalCount">Toplam Kayıt Sayısı</param>
        /// <returns>Data List</returns>
        IEnumerable<T> GetPage(
            int pPage, int pPageSize, out int totalCount);
        /// <summary>
        /// To get all data by filtered, ordered and included or not
        /// </summary>
        /// <returns>Data List</returns>
        IEnumerable<T> Get(bool isAsNoTracking = false);

        /// <summary>
        /// To get all data by filtered, ordered and included or not
        /// </summary>
        /// <returns>Data List</returns>
        T GetFirst();
     

***Log Service definitions***

              public static ResponseBaseDTO Make(T entity, string methodName)
        {
           
            string message = string.Empty;
            if (entity!=null)
                message = ResponseMessage.GetDescription(ResponseMessage.Success, methodName);
            else
                message = ResponseMessage.GetDescription(ResponseMessage.NotFound, methodName);
            ResponseBaseDTO response= new ResponseBaseDTO
            {
                Data = entity,
                Message = message,
                Information = new Information
                {
                    TrackId = Guid.NewGuid().ToString()
                },
                RC = ResponseMessage.Success
            };
           Log.Write(LogEventLevel.Information, message,response);
           return response;
        }

        public static ResponseBaseDTO Make(IEnumerable<T> entity, string methodName)
        {
            string message = string.Empty;
            if (entity.Count() > 0)
                message = ResponseMessage.GetDescription(ResponseMessage.Success, methodName);
            else
                message = ResponseMessage.GetDescription(ResponseMessage.NotFound, methodName);

            ResponseBaseDTO response = new ResponseBaseDTO
            {
                Data = entity,
                Message = message,
                Information = new Information
                {
                    TrackId = Guid.NewGuid().ToString()
                },
                RC = ResponseMessage.Success
            };
            Log.Write(LogEventLevel.Information, message, response);
            return response;
        }
