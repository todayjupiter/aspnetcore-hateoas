﻿using AspNetCore.Hateoas.Formatters;
using AspNetCore.Hateoas.Infrastructure;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class MvcBuilderExtensions
    {
        public static IMvcBuilder AddHateoas(this IMvcBuilder builder, int order = 0, Action<HateoasOptions> options = null)
        {
            if (options != null)
            {
                builder.Services.Configure(options);
            }
            builder.Services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
            builder.AddMvcOptions(o => {
                o.OutputFormatters.Insert(order ,new JsonHateoasFormatter()); });
            return builder;
        }
    }
}
