using Microsoft.AspNetCore.Mvc;
using DotsApi.Data;
using DotsApi.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace DotsApi.Controllers{
    [Route("api/[controller]")]
    [ApiController]
    public class DotsController:ControllerBase{
        private readonly IDataRepository _dataRepository;
        public DotsController(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dot>>> GetAllDataAsync(){
            if(await _dataRepository.Dots.AnyAsync()){
                var data = await _dataRepository.Dots.ToListAsync();
                return data;
            }
            else return NotFound();
        }
        [HttpDelete("{dotId}")]
        public async Task<ActionResult<Dot>> DeleteDotAsync(int dotId){
            Dot? dot = await _dataRepository.Dots.FirstOrDefaultAsync(d=>d.DotId == dotId);
            if(dot is null){
                return NotFound();
            }
            else{
                await _dataRepository.DeleteDotWithComments(dot);
                return Ok();
            }
        }     
    }
}