using desafio_back_end_picpay.Data.DTOs;
using desafio_back_end_picpay.Hypermedia.Constants;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace desafio_back_end_picpay.Hypermedia.Enricher;

public class UserEnricher : ContentResponseEnricher<UserDTO>
{
    protected override Task EnrichModel(UserDTO content, IUrlHelper urlHelper)
    {
        var path = "api/User";
        string link = GetLink(content.Id, urlHelper, path);

        content.Links.Add(new HyperMediaLink()
        {
            Action = HttpActionVerbs.GET,
            Href = link,
            Rel = RelationType.self,
            Type = ResponseTypeFormat.DefaultGet
        });
        content.Links.Add(new HyperMediaLink()
        {
            Action = HttpActionVerbs.POST,
            Href = link,
            Rel = RelationType.self,
            Type = ResponseTypeFormat.DefaultPost
        });
        content.Links.Add(new HyperMediaLink()
        {
            Action = HttpActionVerbs.PUT,
            Href = link,
            Rel = RelationType.self,
            Type = ResponseTypeFormat.DefaultPut
        });
        content.Links.Add(new HyperMediaLink()
        {
            Action = HttpActionVerbs.PATCH,
            Href = link,
            Rel = RelationType.self,
            Type = ResponseTypeFormat.DefaultPatch
        });
        content.Links.Add(new HyperMediaLink()
        {
            Action = HttpActionVerbs.DELETE,
            Href = link,
            Rel = RelationType.self,
            Type = "int"
        });
        return Task.CompletedTask;
    }

    private string GetLink(long id, IUrlHelper urlHelper, string path)
    {
        lock (this)
        {
            var url = new { controller = path, id };
            var links = new StringBuilder(urlHelper.Link("DefaultApi", url)).Replace("%2F", "/").ToString();
            return links;
        };
    }
}
