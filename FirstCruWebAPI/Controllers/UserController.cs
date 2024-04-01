using AutoMapper;
using FirstCruWebAPI.Data;
using FirstCruWebAPI.Models;
using FirstCruWebAPI.Models.Dto;
using Mango.Services.CouponApi.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace FirstCruWebAPI.Controllers
{
    [Route("api/user")]
    [ApiController]

    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext db;
        private ResponseDTO responseDTO;
        private IMapper mapper;
        public UserController(ApplicationDbContext _db, IMapper _mapper)
        {
            db = _db;
            responseDTO = new ResponseDTO();
            mapper = _mapper;
        }
        [HttpGet]
        public ResponseDTO GetUsers()
        {
            try
            {
                IEnumerable<UserRegistration> userList = db.tblUsers.ToList();
                if(userList == null)
                {
                    responseDTO.Message = "Data is not available";
                    responseDTO.IsSuccess = false;
                }
                IEnumerable<UserRegistrationDto> users = mapper.Map<IEnumerable<UserRegistrationDto>>(userList);
                responseDTO.Result = users;
            }
            catch (Exception ex)
            {

                responseDTO.IsSuccess = false;
                responseDTO.Message = ex.Message;
            }
           

            return responseDTO;
        }
        [HttpGet]
        [Route("GetUserByUserId")]
        public ResponseDTO GetUserByUserId(int id)
        {
            try
            {
                UserRegistration user = db.tblUsers.First(x=>x.UserId==id);
                if (user == null)
                {
                    responseDTO.Message = "Data is not available";
                    responseDTO.IsSuccess = false;
                }
                UserRegistrationDto userDto = mapper.Map<UserRegistrationDto>(user);
                responseDTO.Result = userDto;
            }
            catch (Exception ex)
            {

                responseDTO.IsSuccess = false;
                responseDTO.Message = ex.Message;
            }


            return responseDTO;
        }
        [HttpDelete]
        [Route("DeleteUser")]
        public ResponseDTO DeleteUsers(int id)
        {
            try
            {
                UserRegistration user = db.tblUsers.FirstOrDefault(x=>x.UserId==id);
                if (user == null)
                {
                    responseDTO.Message = "Data is not available";
                }
                else
                {
                    db.tblUsers.Remove(user);
                    db.SaveChanges();
                    responseDTO.Message = "Data Deleted";
                }
                
            }
            catch (Exception ex)
            {

                responseDTO.IsSuccess = false;
                responseDTO.Message = ex.Message;
            }


            return responseDTO;
        }
        [HttpPost]
        public ResponseDTO CreateUser([FromBody] UserRegistrationDto userDto)
        {

            try
            {
                if(userDto!=null)
                {
                    UserRegistration user = mapper.Map<UserRegistration>(userDto);

                    db.tblUsers.Add(user);
                    db.SaveChanges();
                    responseDTO.Result = mapper.Map<UserRegistrationDto>(user);
                }
               else
                {
                    responseDTO.IsSuccess = false;
                    responseDTO.Message = "Data is not validated";
                }
                
            }
            catch (Exception ex)
            {

                responseDTO.IsSuccess = false;
                responseDTO.Message = ex.Message;
            }
            return responseDTO;
        }

        [HttpPut]
        public ResponseDTO EditUser([FromBody] UserRegistrationDto userDto)
        {

            try
            {
                if (userDto != null)
                {
                    UserRegistration user = mapper.Map<UserRegistration>(userDto);

                    db.tblUsers.Update(user);
                    db.SaveChanges();
                    responseDTO.Result = mapper.Map<UserRegistrationDto>(user);
                }
                else
                {
                    responseDTO.IsSuccess = false;
                    responseDTO.Message = "Data is not validated";
                }

            }
            catch (Exception ex)
            {

                responseDTO.IsSuccess = false;
                responseDTO.Message = ex.Message;
            }
            return responseDTO;
        }
    }
}
