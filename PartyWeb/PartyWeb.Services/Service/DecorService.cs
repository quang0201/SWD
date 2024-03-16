﻿using AutoMapper;
using BusinessObjects.Models;
using DataAcess.ControllerDAO;
using ModelViews.Models;
using ModelViews.ModelView;
using Reponsitories.Interface;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Tools.Tool;

namespace Services.Service
{
    public class DecorService : IDecorService
    {
        private readonly IDecorRepository _DecorRepo;
        private readonly IMapper _mapper;

        public DecorService(IDecorRepository DecorRepository, IMapper mapper)
        {
            _DecorRepo = DecorRepository;
            _mapper = mapper;
        }

        public async Task<bool> AddDecor(DecorModel Decor, string user)
        {
            try
            {
                if (!Validation.Instance.CheckStringMinMax(Decor.Name, 2, 255))
                {
                    throw new Exception("Length of Name invalid");
                }
                if (Validation.Instance.ValidateInputVietnamese(Decor.Name))
                {
                    throw new Exception("Name contains special letters");
                }
                if (!Validation.Instance.CheckStringMinMax(Decor.Content, 2, 1000))
                {
                    throw new Exception("length of content invalid");
                }
                if (Validation.Instance.ValidateInputVietnamese(Decor.Content))
                {
                    throw new Exception("Content contains special letters");
                }
                if (!Validation.Instance.ValidateInputOnlyNumber(Decor.Price))
                {
                    throw new Exception("price only number");
                }
                if (int.Parse(Decor.Price) <= 0)
                {
                    throw new Exception("number invaild");
                }
                var account = JsonSerializer.Deserialize<Account>(user);
                if (account == null)
                {
                    throw new Exception("User happen error");
                }
                if (account.Role == 0)
                {
                    throw new Exception("you not role host");
                }
                var DecorDTO = new Decor()
                {
                    Name = Decor.Name,
                    Content = Decor.Content,
                    Price = int.Parse(Decor.Price),
                    CreatedBy = account.Id,
                    Status = 2,
                    CreatedTime = DateTime.UtcNow,
                    UpdatedTime = DateTime.UtcNow
                };
                //status 
                //1 là active
                //0 là delete
                //2 là chờ approve
                //3 là bị từ chối
                var result = await _DecorRepo.Add(DecorDTO);
                if (!result)
                {
                    throw new Exception("Add Fail");
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new(ex.Message);
            }
        }

        public async Task<bool> Update(UpdateDecorModel Decor, string user)
        {
            try
            {

                if (!Validation.Instance.CheckStringMinMax(Decor.Decor.Name, 2, 255))
                {
                    throw new Exception("Length of Name invalid");
                }
                if (Validation.Instance.ValidateInputVietnamese(Decor.Decor.Name))
                {
                    throw new Exception("Name contains special letters");
                }
                if (!Validation.Instance.CheckStringMinMax(Decor.Decor.Content, 2, 1000))
                {
                    throw new Exception("length of content invalid");
                }
                if (Validation.Instance.ValidateInputVietnamese(Decor.Decor.Content))
                {
                    throw new Exception("Content contains special letters");
                }
                if (!Validation.Instance.ValidateInputOnlyNumber(Decor.Decor.Price))
                {
                    throw new Exception("price only number");
                }
                if (int.Parse(Decor.Decor.Price) <= 0)
                {
                    throw new Exception("number invaild");
                }
                var account = JsonSerializer.Deserialize<Account>(user);
                if (account == null)
                {
                    throw new Exception("User happen error");
                }
                var DecorDTO = await _DecorRepo.GetById(Decor.Id);
                if (DecorDTO == null)
                {
                    throw new Exception("Decor not found");
                }
                if (DecorDTO.Status != 1)
                {
                    throw new Exception("Decor not active");
                }
                if (account.Role != 1)
                {
                    if (DecorDTO.CreatedBy != account.Id)
                    {
                        throw new Exception("Decor not yours");
                    }
                }
                DecorDTO.Name = Decor.Decor.Name;
                DecorDTO.Price = int.Parse(Decor.Decor.Price);
                DecorDTO.Content = Decor.Decor.Content;
                DecorDTO.UpdatedTime = DateTime.Now;
                var result = await _DecorRepo.Update(DecorDTO);
                return true;
            }
            catch (Exception ex)
            {
                throw new(ex.Message);
            }
        }


        public async Task<bool> Delete(int id, string user)
        {
            try
            {
                if (id <= 0)
                {
                    throw new Exception("number invaild");
                }
                var account = JsonSerializer.Deserialize<Account>(user);
                if (account == null)
                {
                    throw new Exception("User happen error");
                }
                var DecorDTO = await _DecorRepo.GetById(id);
                if (DecorDTO == null)
                {
                    throw new Exception("Decor not found");
                }
                if (DecorDTO.Status != 1)
                {
                    throw new Exception("Decor not active");
                }
                if (account.Role != 1)
                {
                    if (DecorDTO.CreatedBy != account.Id)
                    {
                        throw new Exception("Decor not yours");
                    }
                }
                DecorDTO.Status = 0;
                DecorDTO.DeletedTime = DateTime.Now;
                var result = await _DecorRepo.Update(DecorDTO);
                return true;
            }
            catch (Exception ex)
            {
                throw new(ex.Message);
            }
        }

    }
}
