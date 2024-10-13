using AutoMapper;
using MedicalWebsite.Applicationn.Contract;
using MedicalWebsite.DTOS.Appointment;
using MedicalWebsite.DTOS.ViewResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicalWebsite.Application.Iservices;
using MedicalWebsite.Models;
using MedicalWebsite.Models;
using MedicalWebsite.Models.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

        public async Task<ResultView<CreatorUpdateAppointment>> Create(CreatorUpdateAppointment appointment)
        {
            try
            {
                var Data = (await _AppointmentReposatory.GetAllAsync());
                //var OldApp = Data.Where(c => c.Id == appointment.Id).FirstOrDefault();
                var OldApp = Data.Where(c => c.Id == Guid.Parse(appointment.Id.ToString())).FirstOrDefault();

                if (OldApp != null)
                {
                    return new ResultView<CreatorUpdateAppointment> { Entity = null, IsSuccess = false, Message = "Order Already Exist" };
                }
                else
                {
                    var App = _mapper.Map<Appointment>(appointment);
                    var NewApp = await _AppointmentReposatory.CreateAsync(App);
                    await _AppointmentReposatory.SaveChangesAsync();
                    var ODto = _mapper.Map<CreatorUpdateAppointment>(NewApp);


                    return new ResultView<CreatorUpdateAppointment> { Entity = ODto, IsSuccess = true, Message = "Order Created Successfully" };
                }

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
                var AlldAta = (await _AppointmentReposatory.GetAllAsync());
                var Appointments = AlldAta.Skip(items * (pagenumber - 1)).Take(items)
                                                  .Select(p => new GetAllAppointement()
                                                  {
                                                      Id = p.Id,
                                                      Time = p.BookngTime,
                                                      DoctorName = p.Doctor.UserName,
                                                      Status = p.Status,

                                                      Payment = p.payment.ToString()


                                                  }).ToList();

                var totalItems = AlldAta.Count(c => c.IsDeleted != true);
                var totalPages = (int)Math.Ceiling((double)totalItems / items);

                var resultDataList = new ResultDataList<GetAllAppointement>
                {
                    Entities = Appointments,
                    Count = totalItems,
                    TotalPages = totalPages,
                    CurrentPage = pagenumber,
                    PageSize = items,

                };
                //resultDataList.Entities = Orders;
                //resultDataList.count = AlldAta.Count();
                return resultDataList;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw;
            }
        }

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

       

        public async Task<ResultView<CreatorUpdateAppointment>> HardDelete(CreatorUpdateAppointment Appointment)
        {
            try
            {
                var existingAppointment = await _AppointmentReposatory.GetByIdAsync(Appointment.Id);
                if (existingAppointment == null)
                {
                    return new ResultView<CreatorUpdateAppointment> { Entity = null, IsSuccess = false, Message = "Appointment not found" };
                }
                var OldAppointment = _AppointmentReposatory.DeleteAsync(existingAppointment);
                await _AppointmentReposatory.SaveChangesAsync();

                var bDto = _mapper.Map<CreatorUpdateAppointment>(OldAppointment);
                return new ResultView<CreatorUpdateAppointment> { Entity = bDto, IsSuccess = true, Message = "Deleted Successfully" };
            }
            catch (Exception ex)
            {
                return new ResultView<CreatorUpdateAppointment> { Entity = null, IsSuccess = false, Message = ex.Message };

            }
        }

        public async Task<int> SaveShanges()
        {
            return await _AppointmentReposatory.SaveChangesAsync();
        }

        public async Task<ResultView<CreatorUpdateAppointment>> SoftDelete(CreatorUpdateAppointment Appointment)
        {
            try
            {
                var App = _mapper.Map<Appointment>(Appointment);
                var OldApp = (await _AppointmentReposatory.GetAllAsync()).FirstOrDefault(p => p.Id == Guid.Parse(Appointment.Id.ToString()));
             
                OldApp.IsDeleted = true;
                await _AppointmentReposatory.SaveChangesAsync();
                var AppDto = _mapper.Map<CreatorUpdateAppointment>(OldApp);
                return new ResultView<CreatorUpdateAppointment> { Entity = AppDto, IsSuccess = true, Message = "Deleted Successfully" };
            }
            catch (Exception ex)
            {
                return new ResultView<CreatorUpdateAppointment> { Entity = null, IsSuccess = false, Message = ex.Message };

            }
        }

        public async Task<ResultView<CreatorUpdateAppointment>> Update(CreatorUpdateAppointment Appointment)
        {
            try
            {
                var Data = await _AppointmentReposatory.GetByIdAsync(Appointment.Id);

                if (Data == null)
                {
                    return new ResultView<CreatorUpdateAppointment> { Entity = null, IsSuccess = false, Message = "Appointment Not Found!" };

                }
                else
                {
                    var appointment = _mapper.Map<Appointment>(Appointment);
                    var appEdit = await _AppointmentReposatory.UpdateAsync(appointment);
                    await _AppointmentReposatory.SaveChangesAsync();
                    var appDto = _mapper.Map<CreatorUpdateAppointment>(appEdit);

                    return new ResultView<CreatorUpdateAppointment> { Entity = appDto, IsSuccess = true, Message = "Status Updated Successfully" };
                }

            }
            catch (Exception ex)
            {
                return new ResultView<CreatorUpdateAppointment>
                {
                    Entity = null,
                    IsSuccess = false,
                    Message = $"Something went wrong: {ex.Message}"
                };
                // Console.WriteLine($"An error occurred: {ex.Message}");
                //throw;
            }
        }

       
    }
}
