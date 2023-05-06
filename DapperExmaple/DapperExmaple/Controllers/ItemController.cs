using CoreApiResponse;
using DapperExmaple.Models;
using DapperExmaple.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace DapperExmaple.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ItemController : BaseController
    {
        private readonly IItemsRepository _itemsRepository;
        public ItemController(IItemsRepository itemsRepository )
        {
            _itemsRepository = itemsRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return CustomResult("Data Load Successfully.!",await _itemsRepository.GetAll());

            }catch (Exception ex)
            {
                return CustomResult(ex.Message, System.Net.HttpStatusCode.BadRequest);
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                return CustomResult("Data Load Successfully.!",await _itemsRepository.GetById(id));

            }catch(Exception ex)
            {
                return CustomResult(ex.Message, System.Net.HttpStatusCode.BadRequest);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Items items)
        {
            try
            {
                bool isSave= await _itemsRepository.Add(items);
                if (isSave)
                {
                    return CustomResult("Data has been Saved", items);
                }
                return CustomResult("Data Saved failed", System.Net.HttpStatusCode.BadRequest);

            }catch(Exception ex)
            {
                return CustomResult(ex.Message,System.Net.HttpStatusCode.BadRequest);   
            }
        }
        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] Items items)
        {
            try
            {
                bool isUpdate= await _itemsRepository.Update(items);
                if (isUpdate)
                {
                    return CustomResult("Item has been modified..!", items);
                }
                return CustomResult("Item modified failed.", System.Net.HttpStatusCode.BadRequest);

            }catch( Exception ex)
            {
                return CustomResult(ex.Message, System.Net.HttpStatusCode.BadRequest);
            }
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                bool isDelete= await _itemsRepository.Delete(id);
                if (isDelete)
                {
                    return CustomResult("Item has been deleted.");
                }
                return CustomResult("Item deleted failed.", HttpStatusCode.BadRequest);

            }
            catch(Exception ex)
            {
                return CustomResult(ex.Message, System.Net.HttpStatusCode.BadRequest);
            }
        }
    }
}
