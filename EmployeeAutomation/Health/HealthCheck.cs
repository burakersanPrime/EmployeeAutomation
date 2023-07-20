using em.Persistence.Context;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Drawing.Printing;

namespace EmployeeAutomation.Health
{
    public class HealthCheck : IHealthCheck
    {
        private readonly conDBContext _conDBContext;

        public HealthCheck(conDBContext conDBContext)
        {
            _conDBContext = conDBContext;
        }

        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            try
            {
                // Veritabanı bağlantısını test edio.
                var isConnected = await _conDBContext.Database.CanConnectAsync(cancellationToken);

                if (isConnected)
                {
                    return HealthCheckResult.Healthy("Veritabanı bağlantısı başarılı.");
                }
                else
                {
                    return HealthCheckResult.Unhealthy("Veritabanına bağlantı sağlanamadı.");
                }
            }
            catch (Exception ex)
            {
                return HealthCheckResult.Unhealthy("Hata oluştu: " + ex.Message);
            }
        }
    }
}
