using Microsoft.AspNetCore.Mvc.Filters;

namespace desafio_back_end_picpay.Hypermedia.Abstract;

public interface IResponseEnricher
{
    bool CanEnrich(ResultExecutingContext context);
    Task Enrich(ResultExecutingContext context);
}
