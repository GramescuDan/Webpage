using Microsoft.AspNetCore.Mvc;
using WebPage.DAL.Abstractions.IConfig;


namespace WebPage.API.Controllers
{
    [Route("/api/[controller]")]
    public class ShopItemController: ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ShopItemController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
    }
}