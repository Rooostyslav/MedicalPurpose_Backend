using MedicalPurpose.BLL.DTO.Prescription;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MedicalPurpose.BLL.Services.Implementation
{
	public class QRCodeService : IQRCodeService
	{
        private const int width = 500;
        private const int height = 500;
        private readonly string _pathToQRCodes;

        public QRCodeService()
		{
            _pathToQRCodes = Path.GetFullPath(@"..\MedicalPurpose.API\wwwroot\qrcodes");
		}

		public async Task<string> FindPathToQRCoreAsync(int prescriptionId)
		{
            await Task.CompletedTask;
            string path = Path.Combine(_pathToQRCodes, "prescription" + prescriptionId + ".png");

            if (File.Exists(path))
			{
                return path;
			}

            return "";
        }

		public async Task<string> GenerateQRCodeAsync(PrescriptionDTO prescription)
		{
            string prescriptionString = string.Format("prescriptionId={0}.patientId={1}.doctorId={2}",
                prescription.Id,
                prescription.PatientId,
                prescription.DoctorId);

            var url = string.Format("http://chart.apis.google.com/chart?cht=qr&chs={1}x{2}&chl={0}", 
                prescriptionString, 
                width, 
                height);
            
            WebResponse response = default(WebResponse);
            Stream remoteStream = default(Stream);
            StreamReader readStream = default(StreamReader);
            WebRequest request = WebRequest.Create(url);

            response = await request.GetResponseAsync();
            remoteStream = response.GetResponseStream();
            readStream = new StreamReader(remoteStream);

            Image image = Image.FromStream(remoteStream);

            string fileName = "prescription" + prescription.Id + ".png";
			image.Save(Path.Combine(_pathToQRCodes, fileName));

            response.Close();
            remoteStream.Close();
            readStream.Close();

            return fileName;
        }
	}
}
