using DTOs;
using Microsoft.EntityFrameworkCore;

namespace ITI.Ecommerce.Services
{
    public class PaymentService : IPaymentService
    {

        private readonly ApplicationDbContext _context ;
        public PaymentService(ApplicationDbContext context)

        {
            _context = context;
        }
        public async Task add(PaymentDto paymentDto)
        {
            Payment payment = new Payment()
            {

                PaymentType = paymentDto.PaymentType,
                IsAllowed = paymentDto.IsAllowed
            };
            await _context.Payments.AddAsync(payment);
            _context.SaveChanges();
        }

        //public void Delete(PaymentDto paymentDto)
        //{
        //    throw new NotImplementedException();
        //}

        public async Task<IEnumerable<PaymentDto>> GetAll()
        {
            List<PaymentDto> paymentList = new List<PaymentDto>();
            var Payments = await _context.Payments.ToListAsync();

            foreach (var payment in Payments)
            {
                PaymentDto paymentDto = new PaymentDto()
                {
                    PaymentType = payment.PaymentType,
                    ID = payment.ID,
                    IsAllowed = payment.IsAllowed
                };
                paymentList.Add(paymentDto);
            }

            return paymentList;
        }

        public async Task<PaymentDto> GetById(int id)
        {
            var payment = await _context.Payments.SingleOrDefaultAsync(o => o.ID == id);
            if (payment == null)
            {
                throw new Exception("this Payment is not found");
            }
            else
            {
                PaymentDto paymentDto = new PaymentDto()
                {
                    ID = payment.ID,
                    PaymentType = payment.PaymentType,
                    IsAllowed = payment.IsAllowed
                };
                return paymentDto;
            }
        }

        public void Update(PaymentDto paymentDto)
        {
            Payment payment = new Payment()
            {
                ID = paymentDto.ID,
                PaymentType = paymentDto.PaymentType,
                IsAllowed = paymentDto.IsAllowed
            };

            _context.Update(payment);
            _context.SaveChanges();
        }
    }
}
