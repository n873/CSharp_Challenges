using System;
using System.Net;
using System.Device.Location;

namespace WhereAmI {
    class MapImage {
        public static void Show(GeoCoordinate location) {
            string fileName = $"{location.Latitude:##.000},{location.Longitude:##.000},{location.HorizontalAccuracy:####}m.jpg";
            DownloadMapImage(BuildUri(location), fileName);
            OpenWithDefaultApp(fileName);
        }

        private static void DownloadMapImage(Uri target, string fileName) {
            using (var client = new WebClient()) {
                client.DownloadFile(target, fileName);
            }
        }

        private static Uri BuildUri(GeoCoordinate location) {
            #region HERE App ID & App Code
            string HereApi_AppID = "";
            string HereApi_AppCode = "";
            #endregion

            var HereApi_DNS = "image.maps.cit.api.here.com"; // .cit. is customer integration testing and will need to be removed for prod
            var HereApi_URL = $"https://{HereApi_DNS}/mia/1.6/mapview";
            var HereApi_Secrets = $"&app_id={HereApi_AppID}&app_code={HereApi_AppCode}";

            var latlon = $"&lat={location.Latitude}&lon={location.Longitude}";

            return new Uri(HereApi_URL + $"?u={location.HorizontalAccuracy}" + HereApi_Secrets + latlon);
        }

        private static void OpenWithDefaultApp(string fileName) {
            var processStartinfo = new ProcessStartinfo()
            {
                FileName = "cmd.exe",
                Arguments = $"/C start {filename}",
                WindowStyle = ProcessWindowStyle.Hidden
            };
            Process.Start(processStartinfo);
        }
    }
}