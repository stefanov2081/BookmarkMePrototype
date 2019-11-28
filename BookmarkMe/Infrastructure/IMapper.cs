namespace BookmarkMe.Infrastructure
{
    public interface IMapper<in DomainModel, out ResultModel>
    {
        ResultModel ToResult(DomainModel model);

        ResultModel[] ToResult(DomainModel[] model);
    }
}
