using Microsoft.AspNetCore.Mvc;
using Orleans;

namespace taskProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalcGrainController : ControllerBase
    {
        private readonly IClusterClient _clusterClient;

        public CalcGrainController(IClusterClient clusterClient)
        {
            _clusterClient = clusterClient;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetNum(int id)
        {
            var grain = _clusterClient.GetGrain<ICalcGrain>(id);
            var result = await grain.GetNum();
            return Ok(result);
        }

        [HttpPost("add/{id}")]
        public async Task<IActionResult> AddNum(int id, [FromBody] int numToAdd)
        {
            var grain = _clusterClient.GetGrain<ICalcGrain>(id);
            await grain.Add(numToAdd);
            var newValue = await grain.GetNum();
            return Ok(newValue);
        }
        [HttpPost("minus/{id}")]
        public async Task<IActionResult> MinusNum(int id, [FromBody] int numToAdd)
        {
            var grain = _clusterClient.GetGrain<ICalcGrain>(id);
            await grain.Minus(numToAdd);
            var newValue = await grain.GetNum();
            return Ok(newValue);
        }
    }
}
