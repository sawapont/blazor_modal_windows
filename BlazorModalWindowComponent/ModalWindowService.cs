﻿using Microsoft.AspNetCore.Components;

using System;
using System.Threading.Tasks;

namespace BlazorModalWindowComponent
{
    public class ModalWindowService : AbstractDerivedModalWindowService<object>
    {
        public event Func<RenderFragment, string, Task> OnShow;

        /// <summary>
        /// В типе контента необходимо поле Model для получения модели
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="contentType"></param>
        /// <param name="model">Модель данных</param>
        /// <param name="events">Модель событий</param>
        public Task Show<TModel, TEventModel>(Type contentType, TModel model, TEventModel events, string containerClass)
        {
            if (!HasBaseBlazorComponent(contentType))
            {
                throw new ArgumentException($"{contentType.FullName} must be a Blazor Component");
            }

            var content = new RenderFragment(x => { x.OpenComponent(1, contentType); x.AddAttribute(1, "Model", model); x.AddAttribute(2, "EventModel", events); x.CloseComponent(); });

            return Show(content, containerClass);
        }

        //public Task Show<TModel>(Type contentType, TModel model)
        //{
        //    if (contentType.BaseType != typeof(ComponentBase))
        //    {
        //        throw new ArgumentException($"{contentType.FullName} must be a Blazor Component");
        //    }

        //    var content = new RenderFragment(x => { x.OpenComponent(1, contentType); x.AddAttribute(2, "Model", model); x.CloseComponent(); });

        //    return Show(content);
        //}

        public async Task Show(RenderFragment content, string containerClass)
        {
            if (OnShow != null)
                await OnShow.Invoke(content, containerClass);
        }

        private bool HasBaseBlazorComponent(Type type)
        {
            var typeName = "";
            var objectTypeName = typeof(object).Name;
            do
            {
                if (type == typeof(ComponentBase))
                    return true;

                type = type.BaseType;
                typeName = type.Name;
            }
            while (typeName != objectTypeName);

            return false;
        }
    }
}
