using desafio_back_end_picpay.Hypermedia.Abstract;

namespace desafio_back_end_picpay.Hypermedia.Filters;

public class HyperMediaFilterOptions
{
    public List<IResponseEnricher> ContentResponseEnricherList { get; set; } = new List<IResponseEnricher>();
}
