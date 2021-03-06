﻿namespace ServiceBase.Mvc.Theming
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;

    public class DefaultRequestThemeInfoProvider : IRequestThemeInfoProvider
    {
        private readonly string _defaultTheme;

        public DefaultRequestThemeInfoProvider(
            string defaultTheme = "BaseTheme")
        {
            this._defaultTheme = defaultTheme; 
        }

        public async Task<ThemeInfoResult> DetermineThemeInfoResult(
            HttpContext httpContext)
        {
            var result = new ThemeInfoResult
            {
                RequestTheme = httpContext.Request.Query["theme"],
                DefaultTheme = this._defaultTheme
            };

            // TODO: check if plugin exists
            // TODO: check if plugin is a theme

            if (string.IsNullOrWhiteSpace(result.RequestTheme))
            {
                result.RequestTheme = result.DefaultTheme;
            }

            return result;
        }
    }
}
