namespace desafio_back_end_picpay.Hypermedia.Abstract;

public interface ISupportsHyperMedia
{
    public List<HyperMediaLink> Links { get; set; }
}
