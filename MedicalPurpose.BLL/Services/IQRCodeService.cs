using MedicalPurpose.BLL.DTO.Prescription;
using System.Threading.Tasks;

namespace MedicalPurpose.BLL.Services
{
	public interface IQRCodeService
	{
		Task<string> GenerateQRCodeAsync(PrescriptionDTO prescription);

		Task<string> FindPathToQRCoreAsync(int prescriptionId);
	}
}
