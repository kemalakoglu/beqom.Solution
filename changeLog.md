# Changelog
All notable changes to this project will be documented in this file.

## [1.0.0] - 14-09-2023

### Added
	-changeLog.md
    -src/02-Domain/beqom.Domain.Aggregate/Option/Entities/
    -src/02-Domain/beqom.Domain.Contract/beqom.Domain.Contract/Enum/
    -src/02-Domain/beqom.Domain.Repository/Handlers/
    -src/02-Domain/beqom.Domain.Repository/OptionGenericRepository.cs
    -src/02-Domain/beqom.Domain.Repository/OptionRepository.cs
    -src/03-Application/beqom.Application.CQRS/beqom.Application.EventHandlers/ApplicationService.cs
    -src/03-Application/beqom.Application.Contract/Services/IApplicationService.cs
    -src/04-Presentation/beqom.Presentation.API/Controllers/OptionController.cs
### Changed
    -modified:   README.md
    -modified:   beqom.sln
    -deleted:    src/01-Core/beqom.Core.Contract/IRepository.cs
    -deleted:    src/01-Core/beqom.Core.Contract/IRepositoryQueryHelper.cs
    -modified:   src/01-Core/beqom.Core.Contract/ISerilogLogger.cs
    -deleted:    src/01-Core/beqom.Core.Contract/IUnitOfWork.cs
    -deleted:    src/01-Core/beqom.Core.Contract/JoinedClass/GroupCountResult.cs
    -deleted:    src/01-Core/beqom.Core.Enumeration/Options.cs
    -modified:   src/01-Core/beqom.Core.Helper/BusinessException.cs
    -modified:   src/01-Core/beqom.Core.Helper/CreateAsyncResponse.cs
    -modified:   src/01-Core/beqom.Core.Helper/CreateResponse.cs
    -modified:   src/01-Core/beqom.Core.Helper/ResponseDTO.cs
    -modified:   src/01-Core/beqom.Core.Logger/SerilogLogger.cs
    -modified:   src/02-Domain/beqom.Domain.Aggregate/Base/BaseEntity.cs
    -deleted:    src/02-Domain/beqom.Domain.Aggregate/Base/IBaseService.cs
    -deleted:    src/02-Domain/beqom.Domain.Aggregate/Option/IOptionService.cs
    -deleted:    src/02-Domain/beqom.Domain.Aggregate/Option/Option.cs
    -deleted:    src/02-Domain/beqom.Domain.Aggregate/Option/OptionService.cs
    -deleted:    src/02-Domain/beqom.Domain.Aggregate/Option/OptionServiceHandler.cs
    -modified:   src/02-Domain/beqom.Domain.Aggregate/beqom.Domain.Aggregate.csproj
    -deleted:    src/02-Domain/beqom.Domain.Context/Context/BaseEntity.cs
    -deleted:    src/02-Domain/beqom.Domain.Context/Context/CoreContext.cs
    -deleted:    src/02-Domain/beqom.Domain.Context/beqom.Domain.Context.csproj
    -modified:   src/02-Domain/beqom.Domain.Contract/beqom.Domain.Contract/DTO/Option/OptionRequestDto.cs
    -modified:   src/02-Domain/beqom.Domain.Contract/beqom.Domain.Contract/DTO/Option/OptionResponseDto.cs
    -modified:   src/02-Domain/beqom.Domain.Contract/beqom.Domain.Contract/beqom.Domain.Contract.csproj
    -deleted:    src/02-Domain/beqom.Domain.Repository/MainRepository.cs
    -deleted:    src/02-Domain/beqom.Domain.Repository/RepositoryQueryHelper.cs
    -modified:   src/02-Domain/beqom.Domain.Repository/beqom.Domain.Repository.csproj
    -modified:   src/03-Application/beqom.Application.CQRS/beqom.Application.EventHandlers/Option/OptionQuery.cs
    -modified:   src/03-Application/beqom.Application.CQRS/beqom.Application.EventHandlers/beqom.Application.CommandQuery.csproj
    -deleted:    src/03-Application/beqom.Application.Contract/Services/ICoreApplicationService.cs
    -modified:   src/03-Application/beqom.Application.Service/ApplicationService.cs
    -deleted:    src/04-Presentation/beqom.Presentation.API/Controllers/RefTypeController.cs
    -modified:   src/04-Presentation/beqom.Presentation.API/Extensions/DependencyInjection.cs
    -modified:   src/04-Presentation/beqom.Presentation.API/Extensions/ErrorHandlingMiddleware.cs
    -deleted:    src/04-Presentation/beqom.Presentation.API/Extensions/FluentValidator.cs
    -modified:   src/04-Presentation/beqom.Presentation.API/Extensions/Logger.cs
    -modified:   src/04-Presentation/beqom.Presentation.API/Extensions/Mapping.cs
    -deleted:    src/04-Presentation/beqom.Presentation.API/Extensions/Redis.cs
    -modified:   src/04-Presentation/beqom.Presentation.API/Extensions/Swagger.cs
    -modified:   src/04-Presentation/beqom.Presentation.API/Program.cs
    -modified:   src/04-Presentation/beqom.Presentation.API/Startup.cs
    -modified:   src/04-Presentation/beqom.Presentation.API/beqom.Presentation.API.csproj
    -modified:   src/04-Presentation/beqom.Presentation.API/log.json
    -deleted:    test/beqom.Test.Presentation/beqom.Test.Presentation.csproj
	
	
	
## [1.0.1] - 16-09-2023

### Added	
	-src/01-Core/beqom.Core.Helper/ResponseCodes.cs
    -src/01-Core/beqom.Core.Helper/beqom.Core.Extension.csproj
    -src/02-Domain/beqom.Domain.Aggregate/Extensions.cs
    -src/02-Domain/beqom.Domain.Aggregate/Option/Entities/Option.cs
    -test/beqom.Test.Presentation/OptionTest.cs
    -test/beqom.Test.Presentation/appsettings.json
    -test/beqom.Test.Presentation/beqom.Test.Aggregate.csproj
### Changed	
	-modified:   beqom.sln
    -modified:   changeLog.md
    -deleted:    src/01-Core/beqom.Core.Dapper/Execute.cs
    -deleted:    src/01-Core/beqom.Core.Dapper/Properties/PublishProfiles/FolderProfile.pubxml
    -deleted:    src/01-Core/beqom.Core.Dapper/beqom.Core.Dapper.csproj
    -modified:   src/01-Core/beqom.Core.Helper/BusinessException.cs
    -deleted:    src/01-Core/beqom.Core.Helper/CreateAsyncResponse.cs
    -modified:   src/01-Core/beqom.Core.Helper/CreateResponse.cs
    -deleted:    src/01-Core/beqom.Core.Helper/beqom.Core.Helper.csproj
    -deleted:    src/01-Core/beqom.Core.Resources/AssemblyInfo1.cs
    -deleted:    src/01-Core/beqom.Core.Resources/Properties/PublishProfiles/FolderProfile.pubxml
    -deleted:    src/01-Core/beqom.Core.Resources/RC.Designer.cs
    -deleted:    src/01-Core/beqom.Core.Resources/RC.resx
    -deleted:    src/01-Core/beqom.Core.Resources/ResponseMessage.cs
    -deleted:    src/01-Core/beqom.Core.Resources/beqom.Core.Resources.csproj
    -modified:   src/02-Domain/beqom.Domain.Aggregate/Base/BaseEntity.cs
    -modified:   src/02-Domain/beqom.Domain.Aggregate/Option/Entities/ConfigOption.cs
    -deleted:    src/02-Domain/beqom.Domain.Aggregate/Option/Entities/DefaultOption.cs
    -modified:   src/02-Domain/beqom.Domain.Aggregate/Option/Entities/EmptyOption.cs
    -modified:   src/02-Domain/beqom.Domain.Aggregate/beqom.Domain.Aggregate.csproj
    -modified:   src/02-Domain/beqom.Domain.Contract/beqom.Domain.Contract/DTO/Base/BaseDTO.cs
    -modified:   src/02-Domain/beqom.Domain.Contract/beqom.Domain.Contract/DTO/Option/OptionRequestDto.cs
    -modified:   src/02-Domain/beqom.Domain.Contract/beqom.Domain.Contract/Enum/OptionType.cs
    -modified:   src/02-Domain/beqom.Domain.Contract/beqom.Domain.Contract/Interface/IOptionRepository.cs
    -modified:   src/02-Domain/beqom.Domain.Repository/Handlers/OptionServiceHandler.cs
    -deleted:    src/02-Domain/beqom.Domain.Repository/OptionGenericRepository.cs
    -modified:   src/02-Domain/beqom.Domain.Repository/OptionRepository.cs
    -modified:   src/02-Domain/beqom.Domain.Repository/beqom.Domain.Repository.csproj
    -modified:   src/03-Application/beqom.Application.Contract/beqom.Application.Contract.csproj
    -deleted:    src/03-Application/beqom.Application.Service/ApplicationService.cs
    -deleted:    src/03-Application/beqom.Application.Service/beqom.Application.Service.csproj
    -deleted:    src/03-Application/beqom.Application.UnitOfWork/UnitOfWork.cs
    -deleted:    src/03-Application/beqom.Application.UnitOfWork/beqom.Application.UnitOfWork.csproj
    -modified:   src/04-Presentation/beqom.Presentation.API/Extensions/ErrorHandlingMiddleware.cs
    -modified:   src/04-Presentation/beqom.Presentation.API/Extensions/Mapping.cs
    -modified:   src/04-Presentation/beqom.Presentation.API/appsettings.json
    -modified:   src/04-Presentation/beqom.Presentation.API/beqom.Presentation.API.csproj
    -modified:   src/04-Presentation/beqom.Presentation.API/log.json
    -deleted:    src/04-Presentation/beqom.Presentation.GraphQL/beqom.Presentation.GraphQL/Constants/AuthorizationPolicyName.cs
    -deleted:    src/04-Presentation/beqom.Presentation.GraphQL/beqom.Presentation.GraphQL/Constants/CacheProfileName.cs
    -deleted:    src/04-Presentation/beqom.Presentation.GraphQL/beqom.Presentation.GraphQL/Constants/CorsPolicyName.cs
    -deleted:    src/04-Presentation/beqom.Presentation.GraphQL/beqom.Presentation.GraphQL/Exception/HttpException.cs
    -deleted:    src/04-Presentation/beqom.Presentation.GraphQL/beqom.Presentation.GraphQL/Executer/InstrumentingGraphQLExecutor.cs
    -deleted:    src/04-Presentation/beqom.Presentation.GraphQL/beqom.Presentation.GraphQL/Extensions/ApplicationBuilderExtensions.cs
    -deleted:    src/04-Presentation/beqom.Presentation.GraphQL/beqom.Presentation.GraphQL/Extensions/AuthenticationExtensions.cs
    -deleted:    src/04-Presentation/beqom.Presentation.GraphQL/beqom.Presentation.GraphQL/Extensions/CorsExtensions.cs
    -deleted:    src/04-Presentation/beqom.Presentation.GraphQL/beqom.Presentation.GraphQL/Extensions/CustomExtensions.cs
    -deleted:    src/04-Presentation/beqom.Presentation.GraphQL/beqom.Presentation.GraphQL/Extensions/DependencyInjectionExtensions.cs
    -deleted:    src/04-Presentation/beqom.Presentation.GraphQL/beqom.Presentation.GraphQL/Extensions/GraphQLExtensions.cs
    -deleted:    src/04-Presentation/beqom.Presentation.GraphQL/beqom.Presentation.GraphQL/Extensions/HttpContextExtensions.cs
    -deleted:    src/04-Presentation/beqom.Presentation.GraphQL/beqom.Presentation.GraphQL/Extensions/Mapping.cs
    -deleted:    src/04-Presentation/beqom.Presentation.GraphQL/beqom.Presentation.GraphQL/Extensions/SchemaExtensions.cs
    -deleted:    src/04-Presentation/beqom.Presentation.GraphQL/beqom.Presentation.GraphQL/Extensions/SingletonExtensions.cs
    -deleted:    src/04-Presentation/beqom.Presentation.GraphQL/beqom.Presentation.GraphQL/Extensions/WebHostBuilderExtensions.cs
    -deleted:    src/04-Presentation/beqom.Presentation.GraphQL/beqom.Presentation.GraphQL/Graphs/RefTypes/GetRefTypesResponseGraph.cs
    -deleted:    src/04-Presentation/beqom.Presentation.GraphQL/beqom.Presentation.GraphQL/Graphs/RefTypes/RefTypeGraph.cs
    -deleted:    src/04-Presentation/beqom.Presentation.GraphQL/beqom.Presentation.GraphQL/Middleware/HttpExceptionMiddleware.cs
    -deleted:    src/04-Presentation/beqom.Presentation.GraphQL/beqom.Presentation.GraphQL/Middleware/InternalServerErrorOnExceptionMiddleware.cs
    -deleted:    src/04-Presentation/beqom.Presentation.GraphQL/beqom.Presentation.GraphQL/Options/ApplicationOptions.cs
    -deleted:    src/04-Presentation/beqom.Presentation.GraphQL/beqom.Presentation.GraphQL/Options/CacheProfileOptions.cs
    -deleted:    src/04-Presentation/beqom.Presentation.GraphQL/beqom.Presentation.GraphQL/Options/CompressionOptions.cs
    -deleted:    src/04-Presentation/beqom.Presentation.GraphQL/beqom.Presentation.GraphQL/Options/HttpExceptionMiddlewareOptions.cs
    -deleted:    src/04-Presentation/beqom.Presentation.GraphQL/beqom.Presentation.GraphQL/Program.cs
    -deleted:    src/04-Presentation/beqom.Presentation.GraphQL/beqom.Presentation.GraphQL/Properties/launchSettings.json
    -deleted:    src/04-Presentation/beqom.Presentation.GraphQL/beqom.Presentation.GraphQL/Schemas/MainSchema.cs
    -deleted:    src/04-Presentation/beqom.Presentation.GraphQL/beqom.Presentation.GraphQL/Schemas/RefTypeSchema.cs
    -deleted:    src/04-Presentation/beqom.Presentation.GraphQL/beqom.Presentation.GraphQL/Startup.cs
    -deleted:    src/04-Presentation/beqom.Presentation.GraphQL/beqom.Presentation.GraphQL/appsettings.Development.json
    -deleted:    src/04-Presentation/beqom.Presentation.GraphQL/beqom.Presentation.GraphQL/appsettings.json
    -deleted:    src/04-Presentation/beqom.Presentation.GraphQL/beqom.Presentation.GraphQL/beqom.Presentation.GraphQL.csproj
    -deleted:    src/04-Presentation/beqom.Presentation.GraphQL/beqom.Presentation.GraphQL/mime.types
    -deleted:    src/04-Presentation/beqom.Presentation.GraphQL/beqom.Presentation.GraphQL/nginx.conf
    -deleted:    src/04-Presentation/beqom.Presentation.GraphQL/beqom.Presentation.GraphQL/web.config
    -deleted:    test/beqom.Test.Presentation/OptionRepositoryTest.cs
    -deleted:    test/beqom.Test.Presentation/beqom.Test.Repository.csproj
	
## [1.0.2] - 17-09-2023

### Added	
	-create mode 100644 src/02-Domain/beqom.Domain.Aggregate/Employee/Employee.cs
	-create mode 100644 src/02-Domain/beqom.Domain.Aggregate/Option/DefaultOption.cs
	-create mode 100644 src/02-Domain/beqom.Domain.Aggregate/Option/EmptyOption.cs
	-create mode 100644 src/02-Domain/beqom.Domain.Aggregate/Option/IOption.cs
	-create mode 100644 src/04-Presentation/beqom.Presentation.API/refactor.cs
### Changed		     
	-rename src/02-Domain/beqom.Domain.Aggregate/Option/{Entities => }/ConfigOption.cs (58%)  
	-delete mode 100644 src/02-Domain/beqom.Domain.Aggregate/Option/Entities/EmptyOption.cs
	-rename src/02-Domain/beqom.Domain.Aggregate/Option/{Entities => }/Option.cs (50%)