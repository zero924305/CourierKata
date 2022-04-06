using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Courier_Kata.Model;

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




    }
}
