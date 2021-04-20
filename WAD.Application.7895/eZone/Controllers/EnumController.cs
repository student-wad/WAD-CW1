using eZone.BLL.Enums;
using eZone.DAL.DBO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eZone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnumController : ControllerBase
    {
        [HttpGet("GroupDays")]
        public ActionResult GetGroupDays()
        {
            return Ok(EnumExtensions.GetValues<GroupDays>());
        }

        [HttpGet("GroupLevel")]
        public ActionResult GetGroupLevels()
        {
            return Ok(EnumExtensions.GetValues<GroupLevel>());
        }

        [HttpGet("GroupTime")]
        public ActionResult GetGroupTime()
        {
            return Ok(EnumExtensions.GetValues<GroupTime>());
        }

        [HttpGet("GroupStatus")]
        public ActionResult GetGroupStatus()
        {
            return Ok(EnumExtensions.GetValues<GroupStatus>());
        }

        [HttpGet("PaymentStatus")]
        public ActionResult GetPaymentStatus()
        {
            return Ok(EnumExtensions.GetValues<PaymentStatus>());
        }

        [HttpGet("CourseLevel")]
        public ActionResult GetCourseLevels()
        {
            return Ok(EnumExtensions.GetValues<CourseLevel>());
        }
    }
}
