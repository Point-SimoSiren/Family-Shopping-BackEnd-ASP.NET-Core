using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using ShoppingBackendAPI.Models;

namespace ShoppingBackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingList : ControllerBase
    {
        private shoppingdbContext db = new shoppingdbContext();

        // Get all with hardcoded pincode
        [HttpGet]
        [Route("code/{key}")]
        public ActionResult GetAllItems (string key)
        {
            if (key == "handyshopper")
            {
                try
                {
                    List<Item> listaus = db.Items.ToList();
                    return Ok(listaus);
                }
                catch (Exception e)
                {
                    return BadRequest("Hey Shoper! Something went wrong: " + e);

                }
            }
            else
            {
                return Unauthorized("Wrong or missing key.");
            }
        }


        // Create new
        [HttpPost]
        [Route("code/{key}")]
        public ActionResult CreateNew(string key, [FromBody] Item x)
        {
            if (key == "handyshopper")
            {
                try
                {

                    db.Items.Add(x);
                    db.SaveChanges();
                    return Ok("New item " + x.ItemName + " added!");
                }
                catch (Exception e)
                {
                    return BadRequest(e);
                }
        }
        else
         {
           return Unauthorized("Wrong or missing key.");
         }

     }

        // Remove item
        [HttpDelete]
        [Route("code/{key}/{id}")]
        public ActionResult DeleteOne(string key, int id)
        {
            if (key == "poisto")
            {
                try
                {
                    Item x = db.Items.Find(id);
                    if (x != null)
                    {
                        db.Items.Remove(x);
                        db.SaveChanges();
                        return Ok("Item with id " + id + " was removed.");
                    }
                    else
                    {
                        return NotFound("Item with id " + id + " not found.");
                    }
                }
                catch
                {
                    return BadRequest();
                }
            }
            else
            {
                return Unauthorized("Wrong or missing key.");
            }
         }
     }
 }

