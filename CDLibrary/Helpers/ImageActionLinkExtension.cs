using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.ComponentModel;

namespace CDLibrary.Helpers
{
    public static class ImageActionLinkExtension
    {
        public static MvcHtmlString ImageActionLink(
           this HtmlHelper helper,
           string imageUrl,
           string altText,
           string actionName,
           string controllerName,
           object routeValues,
           object linkHtmlAttributes,
           object imgHtmlAttributes)
        {
            var linkAttributes = AnonymousObjectToKeyValue(linkHtmlAttributes);
            var imgAttributes = AnonymousObjectToKeyValue(imgHtmlAttributes);
            var imgBuilder = new TagBuilder("img");
            imgBuilder.MergeAttribute("src", imageUrl);
            imgBuilder.MergeAttribute("alt", altText);
            imgBuilder.MergeAttributes(imgAttributes, true);
            var urlHelper = new UrlHelper(helper.ViewContext.RequestContext, helper.RouteCollection);
            var linkBuilder = new TagBuilder("a");
            linkBuilder.MergeAttribute("href", urlHelper.Action(actionName, controllerName, routeValues));
            linkBuilder.MergeAttributes(linkAttributes, true);
            var text = linkBuilder.ToString(TagRenderMode.StartTag);
            text += imgBuilder.ToString(TagRenderMode.SelfClosing);
            text += linkBuilder.ToString(TagRenderMode.EndTag);
            return MvcHtmlString.Create(text);
        }

        public static MvcHtmlString ImageActionLink(
            this HtmlHelper helper,
            string imageUrl,
            string altText,
            string actionName,
            object routeValues,
            object imgHtmlAttributes)
        {
            var imgAttributes = AnonymousObjectToKeyValue(imgHtmlAttributes);
            var imgBuilder = new TagBuilder("img");
            imgBuilder.MergeAttribute("src", imageUrl);
            imgBuilder.MergeAttribute("alt", altText);
            imgBuilder.MergeAttributes(imgAttributes, true);
            var urlHelper = new UrlHelper(helper.ViewContext.RequestContext, helper.RouteCollection);
            var linkBuilder = new TagBuilder("a");
            linkBuilder.MergeAttribute("href", urlHelper.Action(actionName, routeValues));
            var text = linkBuilder.ToString(TagRenderMode.StartTag);
            text += imgBuilder.ToString(TagRenderMode.SelfClosing);
            text += linkBuilder.ToString(TagRenderMode.EndTag);
            return MvcHtmlString.Create(text);
        }

        public static MvcHtmlString ImageActionLink(
            this HtmlHelper helper,
            string imageUrl,
            string altText,
            string actionName,
            object routeValues)
        {
            var imgBuilder = new TagBuilder("img");
            imgBuilder.MergeAttribute("src", imageUrl);
            imgBuilder.MergeAttribute("alt", altText);
            var urlHelper = new UrlHelper(helper.ViewContext.RequestContext, helper.RouteCollection);
            var linkBuilder = new TagBuilder("a");
            linkBuilder.MergeAttribute("href", urlHelper.Action(actionName, routeValues));
            var text = linkBuilder.ToString(TagRenderMode.StartTag);
            text += imgBuilder.ToString(TagRenderMode.SelfClosing);
            text += linkBuilder.ToString(TagRenderMode.EndTag);
            return MvcHtmlString.Create(text);
        }

        public static MvcHtmlString ImageActionLink(
            this HtmlHelper helper,
            string imageUrl,
            string altText,
            string actionName)
        {
            var imgBuilder = new TagBuilder("img");
            imgBuilder.MergeAttribute("src", imageUrl);
            imgBuilder.MergeAttribute("alt", altText);
            var urlHelper = new UrlHelper(helper.ViewContext.RequestContext, helper.RouteCollection);
            var linkBuilder = new TagBuilder("a");
            linkBuilder.MergeAttribute("href", urlHelper.Action(actionName));
            var text = linkBuilder.ToString(TagRenderMode.StartTag);
            text += imgBuilder.ToString(TagRenderMode.SelfClosing);
            text += linkBuilder.ToString(TagRenderMode.EndTag);
            return MvcHtmlString.Create(text);
        }

        private static Dictionary<string, object> AnonymousObjectToKeyValue(object anonymousObject)
        {
            var dictionary = new Dictionary<string, object>();
            if (anonymousObject != null)
            {
                foreach (PropertyDescriptor propertyDescriptor in TypeDescriptor.GetProperties(anonymousObject))
                {
                    dictionary.Add(propertyDescriptor.Name, propertyDescriptor.GetValue(anonymousObject));
                }
            }
            return dictionary;
        }
    }
}