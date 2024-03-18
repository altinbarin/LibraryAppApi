using Core.Utilities.Results;

namespace Business.Abstract
{
    public interface IPublisherService
    {
        /// <summary>
        /// Tüm yayın evlerini listeler
        /// </summary>
        /// <returns></returns>
        IResult GetAll();
    }
}
