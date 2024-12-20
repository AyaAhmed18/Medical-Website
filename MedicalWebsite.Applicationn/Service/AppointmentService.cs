﻿using AutoMapper;
using MedicalWebsite.Applicationn.Contract;
using MedicalWebsite.DTOS.Appointment;
using MedicalWebsite.DTOS.ViewResult;
using MedicalWebsite.Applicationn.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MedicalWebsite.Models;
using MedicalWebsite.Models;
using MedicalWebsite.Models.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;
using MedicalWebsite.DTOS.Doctor;
using Microsoft.EntityFrameworkCore;

namespace MedicalWebsite.Applicationn.Service
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _AppointmentReposatory;
        private readonly IMapper _mapper;
        public AppointmentService(IAppointmentRepository AppointmentReposatory, IMapper mapper)
        {
            _AppointmentReposatory = AppointmentReposatory;
            _mapper = mapper;
        }

        //public async Task<ResultView<CreatorUpdateAppointment>> Create(CreatorUpdateAppointment appointment)
        //{
        //    try
        //    {
        //        var existingAppointment = (await _AppointmentReposatory.GetAllAsync())
        //            .FirstOrDefault(p => p.Id == appointment.Id);

        //        if (existingAppointment != null)
        //        {
        //            return new ResultView<CreatorUpdateAppointment>
        //            {
        //                Entity = null,
        //                IsSuccess = false,
        //                Message = "An appointment already exists for this doctor at the specified time."
        //            };
        //        }
        //        var newAppointment = _mapper.Map<Appointment>(appointment);

        //        var createdAppointment = await _AppointmentReposatory.CreateAsync(newAppointment);
        //        await _AppointmentReposatory.SaveChangesAsync();

        //        var createdAppointmentDto = _mapper.Map<CreatorUpdateAppointment>(createdAppointment);

        //        return new ResultView<CreatorUpdateAppointment>
        //        {
        //            Entity = createdAppointmentDto,
        //            IsSuccess = true,
        //            Message = "Appointment created successfully."
        //        };
        //    }
        //    catch (Exception ex)
        //    {
        //        return new ResultView<CreatorUpdateAppointment>
        //        {
        //            Entity = null,
        //            IsSuccess = false,
        //            Message = $"Something went wrong: {ex.Message}"
        //        };
        //    }
        //}


        public async Task<ResultView<CreatorUpdateAppointment>> Create(CreatorUpdateAppointment appointment)
        {
            try
            {
                var newAppointment = _mapper.Map<Appointment>(appointment);
                var createdAppointment = await _AppointmentReposatory.CreateAsync(newAppointment);
                await _AppointmentReposatory.SaveChangesAsync();
                var createdAppointmentDto = _mapper.Map<CreatorUpdateAppointment>(createdAppointment);

                return new ResultView<CreatorUpdateAppointment>
                {
                    Entity = createdAppointmentDto,
                    IsSuccess = true,
                    Message = "Appointment created successfully."
                };
            }
            catch (Exception ex)
            {
                return new ResultView<CreatorUpdateAppointment>
                {
                    Entity = null,
                    IsSuccess = false,
                    Message = $"Something went wrong: {ex.Message}"
                };
            }
        }


        public async Task<ResultDataList<GetAllAppointement>> GetAllPagination(int items, int pagenumber)
        {
            try
            {
                var allData = (await _AppointmentReposatory.GetAllAsync())
                              .Where(c => (bool)!c.IsDeleted)
                              .ToList();

                var appointments = allData.Skip(items * (pagenumber - 1))
                                          .Take(items)
                                          .Select(p => new GetAllAppointement
                                          {
                                              Id = p.Id,
                                              Time = p.BookngTime,
                                              DoctorName = p.Doctor?.UserName ?? "unknown doctor",
                                              PatientName = p.Patient?.UserName ?? "unknown Patient",
                                              Status = p.Status,
                                              Payment = p.payment.ToString()
                                          })
                                          .ToList();

                var totalItems = allData.Count;
                var totalPages = (int)Math.Ceiling((double)totalItems / items);

                var resultDataList = new ResultDataList<GetAllAppointement>
                {
                    Entities = appointments,
                    Count = totalItems,
                    TotalPages = totalPages,
                    CurrentPage = pagenumber,
                    PageSize = items
                };

                return resultDataList;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw;
            }
        }

        //public async Task<ResultDataList<GetAllAppointement>> GetAllPagination(int items, int pagenumber)
        //{
        //    try
        //    {
        //        var AlldAta = (await _AppointmentReposatory.GetAllAsync());
        //        var Appointments = AlldAta.Skip(items * (pagenumber - 1)).Take(items)

        //                                          .Select(p => new GetAllAppointement()
        //                                          {
        //                                              Id = p.Id,
        //                                              Time = p.BookngTime,
        //                                              DoctorName = p.Doctor.UserName,
        //                                              Status = p.Status,

        //                                              Payment = p.payment.ToString()


        //                                          }).ToList();

        //        var totalItems = AlldAta.Count(c => c.IsDeleted != true);
        //        var totalPages = (int)Math.Ceiling((double)totalItems / items);

        //        var resultDataList = new ResultDataList<GetAllAppointement>
        //        {
        //            Entities = Appointments,
        //            Count = totalItems,
        //            TotalPages = totalPages,
        //            CurrentPage = pagenumber,
        //            PageSize = items,

        //        };
        //        return resultDataList;
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"An error occurred: {ex.Message}");
        //        throw;
        //    }
        //}


        //test


        public async Task<CreatorUpdateAppointment> GetOne(Guid ID)
        {
            try
            {
                var b = await _AppointmentReposatory.GetByIdAsync(ID);


                CreatorUpdateAppointment REturnb = _mapper.Map<CreatorUpdateAppointment>(b);

                return REturnb;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw;
            }
        }



        //public async Task<ResultView<CreatorUpdateAppointment>> HardDelete(CreatorUpdateAppointment Appointment)
        //{
        //    try
        //    {
        //        var existingAppointment = await _AppointmentReposatory.GetByIdAsync(Appointment.Id);
        //        if (existingAppointment == null)
        //        {
        //            return new ResultView<CreatorUpdateAppointment> { Entity = null, IsSuccess = false, Message = "Appointment not found" };
        //        }
        //        var OldAppointment = _AppointmentReposatory.DeleteAsync(existingAppointment);
        //        await _AppointmentReposatory.SaveChangesAsync();

        //        var bDto = _mapper.Map<CreatorUpdateAppointment>(OldAppointment);
        //        return new ResultView<CreatorUpdateAppointment> { Entity = bDto, IsSuccess = true, Message = "Deleted Successfully" };
        //    }
        //    catch (Exception ex)
        //    {
        //        return new ResultView<CreatorUpdateAppointment> { Entity = null, IsSuccess = false, Message = ex.Message };

        //    }
        //}


        public async Task<ResultView<CreatorUpdateAppointment>> HardDelete(Guid id)
        {
            try
            {
                var existingAppointment = await _AppointmentReposatory.GetByIdAsync(id);

                if (existingAppointment == null)
                {
                    return new ResultView<CreatorUpdateAppointment>
                    {
                        Entity = null,
                        IsSuccess = false,
                        Message = "Appointment not found"
                    };
                }

                await _AppointmentReposatory.DeleteAsync(existingAppointment);
                await _AppointmentReposatory.SaveChangesAsync();

                var deletedAppointmentDto = _mapper.Map<CreatorUpdateAppointment>(existingAppointment);
                return new ResultView<CreatorUpdateAppointment>
                {
                    Entity = deletedAppointmentDto,
                    IsSuccess = true,
                    Message = "Appointment deleted successfully."
                };
            }
            catch (Exception ex)
            {
                return new ResultView<CreatorUpdateAppointment>
                {
                    Entity = null,
                    IsSuccess = false,
                    Message = $"Something went wrong: {ex.Message}"
                };
            }
        }


        public async Task<int> SaveShanges()
        {
            return await _AppointmentReposatory.SaveChangesAsync();
        }

        //public async Task<ResultView<CreatorUpdateAppointment>> SoftDeleten(CreatorUpdateAppointment Appointment)
        //{
        //    try
        //    {
        //        var App = _mapper.Map<Appointment>(Appointment);
        //        var OldApp = (await _AppointmentReposatory.GetAllAsync()).FirstOrDefault(p => p.Id == Guid.Parse(Appointment.Id.ToString()));

        //        OldApp.IsDeleted = true;
        //        await _AppointmentReposatory.SaveChangesAsync();
        //        var AppDto = _mapper.Map<CreatorUpdateAppointment>(OldApp);
        //        return new ResultView<CreatorUpdateAppointment> { Entity = AppDto, IsSuccess = true, Message = "Deleted Successfully" };
        //    }
        //    catch (Exception ex)
        //    {
        //        return new ResultView<CreatorUpdateAppointment> { Entity = null, IsSuccess = false, Message = ex.Message };

        //    }
        //}

        public async Task<ResultView<CreatorUpdateAppointment>> SoftDelete(Guid id)
        {
            try
            {
                var OldApp = await _AppointmentReposatory.GetByIdAsync(id);

                if (OldApp == null)
                {
                    return new ResultView<CreatorUpdateAppointment>
                    {
                        Entity = null,
                        IsSuccess = false,
                        Message = "Appointment not found"
                    };
                }

                OldApp.IsDeleted = true;
                await _AppointmentReposatory.SaveChangesAsync();

                var AppDto = _mapper.Map<CreatorUpdateAppointment>(OldApp);

                return new ResultView<CreatorUpdateAppointment>
                {
                    Entity = AppDto,
                    IsSuccess = true,
                    Message = "Deleted successfully"
                };
            }
            catch (Exception ex)
            {
                return new ResultView<CreatorUpdateAppointment>
                {
                    Entity = null,
                    IsSuccess = false,
                    Message = $"Something went wrong: {ex.Message}"
                };
            }
        }


        //public async Task<ResultView<CreatorUpdateAppointment>> Update(CreatorUpdateAppointment Appointment)
        //{
        //    try
        //    {
        //        var Data = await _AppointmentReposatory.GetByIdAsync(Appointment.Id);

        //        if (Data == null)
        //        {
        //            return new ResultView<CreatorUpdateAppointment> { Entity = null, IsSuccess = false, Message = "Appointment Not Found!" };

        //        }
        //        else
        //        {
        //            var appointment = _mapper.Map<Appointment>(Appointment);
        //            var appEdit = await _AppointmentReposatory.UpdateAsync(appointment);
        //            await _AppointmentReposatory.SaveChangesAsync();
        //            var appDto = _mapper.Map<CreatorUpdateAppointment>(appEdit);

        //            return new ResultView<CreatorUpdateAppointment> { Entity = appDto, IsSuccess = true, Message = "Status Updated Successfully" };
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        return new ResultView<CreatorUpdateAppointment>
        //        {
        //            Entity = null,
        //            IsSuccess = false,
        //            Message = $"Something went wrong: {ex.Message}"
        //        };
        //        // Console.WriteLine($"An error occurred: {ex.Message}");
        //        //throw;
        //    }
        //}

        public async Task<ResultView<CreatorUpdateAppointment>> Update(Guid id, CreatorUpdateAppointment appointmentDto)
        {
            try
            {
                var existingAppointment = await _AppointmentReposatory.GetByIdAsync(id);

                
                _mapper.Map(appointmentDto, existingAppointment);

                var updatedAppointment = await _AppointmentReposatory.UpdateAsync(existingAppointment);
                await _AppointmentReposatory.SaveChangesAsync();

                var updatedAppointmentDto = _mapper.Map<CreatorUpdateAppointment>(updatedAppointment);

                return new ResultView<CreatorUpdateAppointment>
                {
                    Entity = updatedAppointmentDto,
                    IsSuccess = true,
                    Message = "Appointment updated successfully."
                };
            }
            catch (Exception ex)
            {
                return new ResultView<CreatorUpdateAppointment>
                {
                    Entity = null,
                    IsSuccess = false,
                    Message = $"Something went wrong: {ex.Message}"
                };
            }
        }

    }
}
