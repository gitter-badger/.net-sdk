﻿namespace DreamFactory.Api.Implementation
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using DreamFactory.Http;
    using DreamFactory.Model.Database;
    using DreamFactory.Model.System.App;
    using DreamFactory.Model.System.AppGroup;
    using DreamFactory.Model.System.Email;
    using DreamFactory.Model.System.Event;
    using DreamFactory.Model.System.Role;
    using DreamFactory.Model.System.Service;
    using DreamFactory.Model.System.User;

    internal partial class SystemApi
    {
        public Task<IEnumerable<AppResponse>> UpdateAppsAsync(SqlQuery query, params AppRequest[] apps)
        {
            return RequestWithPayloadAsync<AppRequest, AppResponse>(
                method: HttpMethod.Patch,
                resource: "app", 
                query: query, 
                payload: apps
                );
        }

        public Task<IEnumerable<AppGroupResponse>> UpdateAppGroupsAsync(SqlQuery query, params AppGroupRequest[] appGroups)
        {
            return RequestWithPayloadAsync<AppGroupRequest, AppGroupResponse>(
                method: HttpMethod.Patch,
                resource: "app_group",
                query: query,
                payload: appGroups
                );
        }

        public Task<IEnumerable<RoleResponse>> UpdateRolesAsync(SqlQuery query, params RoleRequest[] roles)
        {
            return RequestWithPayloadAsync<RoleRequest, RoleResponse>(
                method: HttpMethod.Patch,
                resource: "role",
                query: query,
                payload: roles
                );
        }

        public Task<IEnumerable<UserResponse>> UpdateUsersAsync(SqlQuery query, params UserRequest[] users)
        {
            return RequestWithPayloadAsync<UserRequest, UserResponse>(
                method: HttpMethod.Patch,
                resource: "user",
                query: query,
                payload: users
                );
        }

        public Task<IEnumerable<ServiceResponse>> UpdateServicesAsync(SqlQuery query, params ServiceRequest[] services)
        {
            return RequestWithPayloadAsync<ServiceRequest, ServiceResponse>(
                method: HttpMethod.Patch,
                resource: "services",
                query: query,
                payload: services
                );
        }

        public Task<IEnumerable<EmailTemplateResponse>> UpdateEmailTemplatesAsync(SqlQuery query, params EmailTemplateRequest[] templates)
        {
            return RequestWithPayloadAsync<EmailTemplateRequest, EmailTemplateResponse>(
                method: HttpMethod.Patch,
                resource: "email_template",
                query: query,
                payload: templates
                );
        }

        public Task<EventScriptResponse> UpdateEventScriptAsync(string eventName, SqlQuery query, EventScriptRequest eventScript)
        {
            return RequestWithPayloadAsync<EventScriptRequest, EventScriptResponse>(
                method: HttpMethod.Patch,
                resource: "event", 
                query: query, 
                payload: eventScript
                );
        }
    }
}
