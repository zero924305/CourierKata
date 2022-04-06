using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Courier_Kata.Model;
using System.Text.Json;

namespace Courier_Kata.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParcelController : ControllerBase
    {
        // GET: api/<ParcelController>
        [HttpGet("{length_mm},{width_mm},{height_mm},{weight_perG},{IsHeavy}")]
        public Parcel Get(int length_mm, int width_mm, int height_mm, int weight_perG, bool IsHeavy)
        {
            Parcel data = new(length_mm, width_mm, height_mm, weight_perG, IsHeavy);
            return data;
            //Return suceeful
        }

        //Order page
        [HttpPost("post")]
        public JsonResult Post([FromBody] JsonElement element, bool IsSpeedy)
        {
            string json = element.ToString();
            List<Parcel> parcels = JsonSerializer.Deserialize<List<Parcel>>(json);

            Order orderDate = new() 
            { 
                OrderParcelDetails = parcels, IsSpeedyOrder = IsSpeedy 
            };

            return new JsonResult(orderDate);

        }


    }
}
