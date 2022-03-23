﻿using Xunit;

namespace TDDWeather
{
    public class TDDWeatherTests
    {
        private const string CITY = "Burlington";
        private const string STATE = "NC";
        private const string COUNTRY = "US";
        private const double LATITUDE = 36.0957;
        private const double LONGITUDE = -79.4378;
     
        private IHandlersProvider provider = new TestHandlersProvider();
        
        [Fact]
        public void GivenTemperatureInCelsius_WhenConverted_ThenReturnsFahrenheit()
        {
            Assert.Equal(122, Converters.CelsiusToFahrenheit(50));
            Assert.Equal(68, Converters.CelsiusToFahrenheit(20));
            Assert.Equal(32, Converters.CelsiusToFahrenheit(0));
        }

        [Fact]
        public void GivenNonExistentLocation_WhenLocationQueryHandled_ThenReturnsNull()
        {
            Assert.Null(provider.GetLocationQueryHandler().GetLocationFor(null, null, null));
        }

        [Fact]
        public void GivenValidLocation_WhenLocationQueryHandled_ThenReturnsValidResponse()
        {
            ILocation location = provider.GetLocationQueryHandler().GetLocationFor(CITY, COUNTRY, STATE);
            Assert.NotNull(location);
            Assert.Equal(CITY, location.GetCity());
            Assert.Equal(LATITUDE, location.GetLatitude());
            Assert.Equal(LONGITUDE, location.GetLongitude());
        }

        private string weatherForBurlingtonQuery = "https://api.openweathermap.org/data/2.5/weather?lat=36.0957&lon=-79.4378&appid=abcd";
        private const string weatherForBurlingtonResponse = "{\"coord\":{\"lon\":-79.4378,\"lat\":36.0957},\"weather\":[{\"id\":804,\"main\":\"Clouds\",\"description\":\"overcast clouds\",\"icon\":\"04d\"}],\"base\":\"stations\",\"main\":{\"temp\":287.38,\"feels_like\":287.13,\"temp_min\":286.75,\"temp_max\":288.5,\"pressure\":1015,\"humidity\":87},\"visibility\":10000,\"wind\":{\"speed\":2.06,\"deg\":120},\"clouds\":{\"all\":100},\"dt\":1648043284,\"sys\":{\"type\":1,\"id\":3521,\"country\":\"US\",\"sunrise\":1648034218,\"sunset\":1648078293},\"timezone\":-14400,\"id\":4458228,\"name\":\"Burlington\",\"cod\":200}";

        private string weatherFor5DaysQuery = "https://api.openweathermap.org/data/2.5/forecast?lat=36.0957&lon=-79.4378&appid=abcd";
        private string weatherFor5DaysResponse = "{\"cod\":\"200\",\"message\":0,\"cnt\":40,\"list\":[{\"dt\":1648047600,\"main\":{\"temp\":287.53,\"feels_like\":287.43,\"temp_min\":287.53,\"temp_max\":289.28,\"pressure\":1014,\"sea_level\":1014,\"grnd_level\":991,\"humidity\":92,\"temp_kf\":-1.75},\"weather\":[{\"id\":500,\"main\":\"Rain\",\"description\":\"light rain\",\"icon\":\"10d\"}],\"clouds\":{\"all\":100},\"wind\":{\"speed\":5.67,\"deg\":148,\"gust\":14.68},\"visibility\":10000,\"pop\":0.39,\"rain\":{\"3h\":0.14},\"sys\":{\"pod\":\"d\"},\"dt_txt\":\"2022-03-23 15:00:00\"},{\"dt\":1648058400,\"main\":{\"temp\":288.62,\"feels_like\":288.65,\"temp_min\":288.62,\"temp_max\":290.79,\"pressure\":1013,\"sea_level\":1013,\"grnd_level\":988,\"humidity\":93,\"temp_kf\":-2.17},\"weather\":[{\"id\":501,\"main\":\"Rain\",\"description\":\"moderate rain\",\"icon\":\"10d\"}],\"clouds\":{\"all\":100},\"wind\":{\"speed\":5.15,\"deg\":163,\"gust\":12.97},\"visibility\":10000,\"pop\":0.98,\"rain\":{\"3h\":8.06},\"sys\":{\"pod\":\"d\"},\"dt_txt\":\"2022-03-23 18:00:00\"},{\"dt\":1648069200,\"main\":{\"temp\":290.13,\"feels_like\":290.34,\"temp_min\":290.13,\"temp_max\":291.43,\"pressure\":1011,\"sea_level\":1011,\"grnd_level\":986,\"humidity\":94,\"temp_kf\":-1.3},\"weather\":[{\"id\":501,\"main\":\"Rain\",\"description\":\"moderate rain\",\"icon\":\"10d\"}],\"clouds\":{\"all\":100},\"wind\":{\"speed\":6.78,\"deg\":180,\"gust\":13.53},\"visibility\":3120,\"pop\":1,\"rain\":{\"3h\":10.79},\"sys\":{\"pod\":\"d\"},\"dt_txt\":\"2022-03-23 21:00:00\"},{\"dt\":1648080000,\"main\":{\"temp\":291.31,\"feels_like\":291.69,\"temp_min\":291.31,\"temp_max\":291.31,\"pressure\":1010,\"sea_level\":1010,\"grnd_level\":987,\"humidity\":96,\"temp_kf\":0},\"weather\":[{\"id\":501,\"main\":\"Rain\",\"description\":\"moderate rain\",\"icon\":\"10n\"}],\"clouds\":{\"all\":100},\"wind\":{\"speed\":4.9,\"deg\":177,\"gust\":13.29},\"visibility\":10000,\"pop\":1,\"rain\":{\"3h\":10.53},\"sys\":{\"pod\":\"n\"},\"dt_txt\":\"2022-03-24 00:00:00\"},{\"dt\":1648090800,\"main\":{\"temp\":291.7,\"feels_like\":292.07,\"temp_min\":291.7,\"temp_max\":291.7,\"pressure\":1011,\"sea_level\":1011,\"grnd_level\":987,\"humidity\":94,\"temp_kf\":0},\"weather\":[{\"id\":500,\"main\":\"Rain\",\"description\":\"light rain\",\"icon\":\"10n\"}],\"clouds\":{\"all\":100},\"wind\":{\"speed\":6.52,\"deg\":193,\"gust\":13.07},\"visibility\":10000,\"pop\":0.85,\"rain\":{\"3h\":0.5},\"sys\":{\"pod\":\"n\"},\"dt_txt\":\"2022-03-24 03:00:00\"},{\"dt\":1648101600,\"main\":{\"temp\":290.15,\"feels_like\":290.39,\"temp_min\":290.15,\"temp_max\":290.15,\"pressure\":1011,\"sea_level\":1011,\"grnd_level\":988,\"humidity\":95,\"temp_kf\":0},\"weather\":[{\"id\":500,\"main\":\"Rain\",\"description\":\"light rain\",\"icon\":\"10n\"}],\"clouds\":{\"all\":100},\"wind\":{\"speed\":5.26,\"deg\":201,\"gust\":11.95},\"visibility\":10000,\"pop\":0.56,\"rain\":{\"3h\":0.13},\"sys\":{\"pod\":\"n\"},\"dt_txt\":\"2022-03-24 06:00:00\"},{\"dt\":1648112400,\"main\":{\"temp\":289.08,\"feels_like\":289.26,\"temp_min\":289.08,\"temp_max\":289.08,\"pressure\":1010,\"sea_level\":1010,\"grnd_level\":987,\"humidity\":97,\"temp_kf\":0},\"weather\":[{\"id\":804,\"main\":\"Clouds\",\"description\":\"overcast clouds\",\"icon\":\"04n\"}],\"clouds\":{\"all\":100},\"wind\":{\"speed\":3.81,\"deg\":191,\"gust\":9.17},\"visibility\":10000,\"pop\":0.03,\"sys\":{\"pod\":\"n\"},\"dt_txt\":\"2022-03-24 09:00:00\"},{\"dt\":1648123200,\"main\":{\"temp\":288.37,\"feels_like\":288.4,\"temp_min\":288.37,\"temp_max\":288.37,\"pressure\":1012,\"sea_level\":1012,\"grnd_level\":988,\"humidity\":94,\"temp_kf\":0},\"weather\":[{\"id\":500,\"main\":\"Rain\",\"description\":\"light rain\",\"icon\":\"10d\"}],\"clouds\":{\"all\":100},\"wind\":{\"speed\":3.98,\"deg\":214,\"gust\":10.19},\"visibility\":10000,\"pop\":0.55,\"rain\":{\"3h\":0.77},\"sys\":{\"pod\":\"d\"},\"dt_txt\":\"2022-03-24 12:00:00\"},{\"dt\":1648134000,\"main\":{\"temp\":287.73,\"feels_like\":287.65,\"temp_min\":287.73,\"temp_max\":287.73,\"pressure\":1012,\"sea_level\":1012,\"grnd_level\":989,\"humidity\":92,\"temp_kf\":0},\"weather\":[{\"id\":500,\"main\":\"Rain\",\"description\":\"light rain\",\"icon\":\"10d\"}],\"clouds\":{\"all\":100},\"wind\":{\"speed\":4.46,\"deg\":208,\"gust\":9.73},\"visibility\":10000,\"pop\":0.68,\"rain\":{\"3h\":1.24},\"sys\":{\"pod\":\"d\"},\"dt_txt\":\"2022-03-24 15:00:00\"},{\"dt\":1648144800,\"main\":{\"temp\":288.82,\"feels_like\":288.56,\"temp_min\":288.82,\"temp_max\":288.82,\"pressure\":1010,\"sea_level\":1010,\"grnd_level\":987,\"humidity\":81,\"temp_kf\":0},\"weather\":[{\"id\":500,\"main\":\"Rain\",\"description\":\"light rain\",\"icon\":\"10d\"}],\"clouds\":{\"all\":100},\"wind\":{\"speed\":5.66,\"deg\":207,\"gust\":8.98},\"visibility\":10000,\"pop\":0.64,\"rain\":{\"3h\":0.13},\"sys\":{\"pod\":\"d\"},\"dt_txt\":\"2022-03-24 18:00:00\"},{\"dt\":1648155600,\"main\":{\"temp\":286.77,\"feels_like\":286.25,\"temp_min\":286.77,\"temp_max\":286.77,\"pressure\":1009,\"sea_level\":1009,\"grnd_level\":986,\"humidity\":79,\"temp_kf\":0},\"weather\":[{\"id\":804,\"main\":\"Clouds\",\"description\":\"overcast clouds\",\"icon\":\"04d\"}],\"clouds\":{\"all\":100},\"wind\":{\"speed\":5.81,\"deg\":212,\"gust\":11.54},\"visibility\":10000,\"pop\":0.33,\"sys\":{\"pod\":\"d\"},\"dt_txt\":\"2022-03-24 21:00:00\"},{\"dt\":1648166400,\"main\":{\"temp\":285.15,\"feels_like\":284.29,\"temp_min\":285.15,\"temp_max\":285.15,\"pressure\":1011,\"sea_level\":1011,\"grnd_level\":987,\"humidity\":72,\"temp_kf\":0},\"weather\":[{\"id\":804,\"main\":\"Clouds\",\"description\":\"overcast clouds\",\"icon\":\"04n\"}],\"clouds\":{\"all\":100},\"wind\":{\"speed\":5.28,\"deg\":213,\"gust\":11.47},\"visibility\":10000,\"pop\":0.25,\"sys\":{\"pod\":\"n\"},\"dt_txt\":\"2022-03-25 00:00:00\"},{\"dt\":1648177200,\"main\":{\"temp\":283.43,\"feels_like\":282.5,\"temp_min\":283.43,\"temp_max\":283.43,\"pressure\":1011,\"sea_level\":1011,\"grnd_level\":987,\"humidity\":76,\"temp_kf\":0},\"weather\":[{\"id\":804,\"main\":\"Clouds\",\"description\":\"overcast clouds\",\"icon\":\"04n\"}],\"clouds\":{\"all\":99},\"wind\":{\"speed\":2.9,\"deg\":224,\"gust\":8.49},\"visibility\":10000,\"pop\":0,\"sys\":{\"pod\":\"n\"},\"dt_txt\":\"2022-03-25 03:00:00\"},{\"dt\":1648188000,\"main\":{\"temp\":282.09,\"feels_like\":280.39,\"temp_min\":282.09,\"temp_max\":282.09,\"pressure\":1012,\"sea_level\":1012,\"grnd_level\":988,\"humidity\":74,\"temp_kf\":0},\"weather\":[{\"id\":804,\"main\":\"Clouds\",\"description\":\"overcast clouds\",\"icon\":\"04n\"}],\"clouds\":{\"all\":99},\"wind\":{\"speed\":3,\"deg\":269,\"gust\":8.38},\"visibility\":10000,\"pop\":0,\"sys\":{\"pod\":\"n\"},\"dt_txt\":\"2022-03-25 06:00:00\"},{\"dt\":1648198800,\"main\":{\"temp\":280.03,\"feels_like\":277.93,\"temp_min\":280.03,\"temp_max\":280.03,\"pressure\":1011,\"sea_level\":1011,\"grnd_level\":987,\"humidity\":70,\"temp_kf\":0},\"weather\":[{\"id\":802,\"main\":\"Clouds\",\"description\":\"scattered clouds\",\"icon\":\"03n\"}],\"clouds\":{\"all\":44},\"wind\":{\"speed\":2.97,\"deg\":249,\"gust\":8.13},\"visibility\":10000,\"pop\":0,\"sys\":{\"pod\":\"n\"},\"dt_txt\":\"2022-03-25 09:00:00\"},{\"dt\":1648209600,\"main\":{\"temp\":279.76,\"feels_like\":277.72,\"temp_min\":279.76,\"temp_max\":279.76,\"pressure\":1012,\"sea_level\":1012,\"grnd_level\":988,\"humidity\":75,\"temp_kf\":0},\"weather\":[{\"id\":801,\"main\":\"Clouds\",\"description\":\"few clouds\",\"icon\":\"02d\"}],\"clouds\":{\"all\":24},\"wind\":{\"speed\":2.81,\"deg\":237,\"gust\":7.93},\"visibility\":10000,\"pop\":0,\"sys\":{\"pod\":\"d\"},\"dt_txt\":\"2022-03-25 12:00:00\"},{\"dt\":1648220400,\"main\":{\"temp\":286.65,\"feels_like\":285.36,\"temp_min\":286.65,\"temp_max\":286.65,\"pressure\":1011,\"sea_level\":1011,\"grnd_level\":988,\"humidity\":50,\"temp_kf\":0},\"weather\":[{\"id\":800,\"main\":\"Clear\",\"description\":\"clear sky\",\"icon\":\"01d\"}],\"clouds\":{\"all\":7},\"wind\":{\"speed\":5.82,\"deg\":257,\"gust\":10.33},\"visibility\":10000,\"pop\":0,\"sys\":{\"pod\":\"d\"},\"dt_txt\":\"2022-03-25 15:00:00\"},{\"dt\":1648231200,\"main\":{\"temp\":286.37,\"feels_like\":285.18,\"temp_min\":286.37,\"temp_max\":286.37,\"pressure\":1010,\"sea_level\":1010,\"grnd_level\":987,\"humidity\":55,\"temp_kf\":0},\"weather\":[{\"id\":802,\"main\":\"Clouds\",\"description\":\"scattered clouds\",\"icon\":\"03d\"}],\"clouds\":{\"all\":37},\"wind\":{\"speed\":5.67,\"deg\":259,\"gust\":9.51},\"visibility\":10000,\"pop\":0,\"sys\":{\"pod\":\"d\"},\"dt_txt\":\"2022-03-25 18:00:00\"},{\"dt\":1648242000,\"main\":{\"temp\":287.56,\"feels_like\":286.41,\"temp_min\":287.56,\"temp_max\":287.56,\"pressure\":1009,\"sea_level\":1009,\"grnd_level\":985,\"humidity\":52,\"temp_kf\":0},\"weather\":[{\"id\":804,\"main\":\"Clouds\",\"description\":\"overcast clouds\",\"icon\":\"04d\"}],\"clouds\":{\"all\":88},\"wind\":{\"speed\":5.3,\"deg\":264,\"gust\":9.6},\"visibility\":10000,\"pop\":0,\"sys\":{\"pod\":\"d\"},\"dt_txt\":\"2022-03-25 21:00:00\"},{\"dt\":1648252800,\"main\":{\"temp\":283.34,\"feels_like\":282.24,\"temp_min\":283.34,\"temp_max\":283.34,\"pressure\":1009,\"sea_level\":1009,\"grnd_level\":985,\"humidity\":70,\"temp_kf\":0},\"weather\":[{\"id\":803,\"main\":\"Clouds\",\"description\":\"broken clouds\",\"icon\":\"04n\"}],\"clouds\":{\"all\":80},\"wind\":{\"speed\":2.5,\"deg\":282,\"gust\":5.01},\"visibility\":10000,\"pop\":0,\"sys\":{\"pod\":\"n\"},\"dt_txt\":\"2022-03-26 00:00:00\"},{\"dt\":1648263600,\"main\":{\"temp\":281.62,\"feels_like\":278.88,\"temp_min\":281.62,\"temp_max\":281.62,\"pressure\":1010,\"sea_level\":1010,\"grnd_level\":986,\"humidity\":69,\"temp_kf\":0},\"weather\":[{\"id\":802,\"main\":\"Clouds\",\"description\":\"scattered clouds\",\"icon\":\"03n\"}],\"clouds\":{\"all\":47},\"wind\":{\"speed\":4.88,\"deg\":282,\"gust\":11.96},\"visibility\":10000,\"pop\":0,\"sys\":{\"pod\":\"n\"},\"dt_txt\":\"2022-03-26 03:00:00\"},{\"dt\":1648274400,\"main\":{\"temp\":279.59,\"feels_like\":276.28,\"temp_min\":279.59,\"temp_max\":279.59,\"pressure\":1011,\"sea_level\":1011,\"grnd_level\":987,\"humidity\":73,\"temp_kf\":0},\"weather\":[{\"id\":802,\"main\":\"Clouds\",\"description\":\"scattered clouds\",\"icon\":\"03n\"}],\"clouds\":{\"all\":27},\"wind\":{\"speed\":5.02,\"deg\":291,\"gust\":10.89},\"visibility\":10000,\"pop\":0,\"sys\":{\"pod\":\"n\"},\"dt_txt\":\"2022-03-26 06:00:00\"},{\"dt\":1648285200,\"main\":{\"temp\":277.99,\"feels_like\":275.02,\"temp_min\":277.99,\"temp_max\":277.99,\"pressure\":1009,\"sea_level\":1009,\"grnd_level\":985,\"humidity\":78,\"temp_kf\":0},\"weather\":[{\"id\":801,\"main\":\"Clouds\",\"description\":\"few clouds\",\"icon\":\"02n\"}],\"clouds\":{\"all\":23},\"wind\":{\"speed\":3.66,\"deg\":232,\"gust\":10.27},\"visibility\":10000,\"pop\":0,\"sys\":{\"pod\":\"n\"},\"dt_txt\":\"2022-03-26 09:00:00\"},{\"dt\":1648296000,\"main\":{\"temp\":279.08,\"feels_like\":275.59,\"temp_min\":279.08,\"temp_max\":279.08,\"pressure\":1009,\"sea_level\":1009,\"grnd_level\":985,\"humidity\":76,\"temp_kf\":0},\"weather\":[{\"id\":802,\"main\":\"Clouds\",\"description\":\"scattered clouds\",\"icon\":\"03d\"}],\"clouds\":{\"all\":40},\"wind\":{\"speed\":5.14,\"deg\":246,\"gust\":13.9},\"visibility\":10000,\"pop\":0,\"sys\":{\"pod\":\"d\"},\"dt_txt\":\"2022-03-26 12:00:00\"},{\"dt\":1648306800,\"main\":{\"temp\":283.87,\"feels_like\":282.17,\"temp_min\":283.87,\"temp_max\":283.87,\"pressure\":1010,\"sea_level\":1010,\"grnd_level\":986,\"humidity\":45,\"temp_kf\":0},\"weather\":[{\"id\":804,\"main\":\"Clouds\",\"description\":\"overcast clouds\",\"icon\":\"04d\"}],\"clouds\":{\"all\":100},\"wind\":{\"speed\":6.96,\"deg\":285,\"gust\":12.22},\"visibility\":10000,\"pop\":0,\"sys\":{\"pod\":\"d\"},\"dt_txt\":\"2022-03-26 15:00:00\"},{\"dt\":1648317600,\"main\":{\"temp\":286.99,\"feels_like\":285.37,\"temp_min\":286.99,\"temp_max\":286.99,\"pressure\":1006,\"sea_level\":1006,\"grnd_level\":983,\"humidity\":36,\"temp_kf\":0},\"weather\":[{\"id\":804,\"main\":\"Clouds\",\"description\":\"overcast clouds\",\"icon\":\"04d\"}],\"clouds\":{\"all\":98},\"wind\":{\"speed\":8.95,\"deg\":260,\"gust\":15.1},\"visibility\":10000,\"pop\":0,\"sys\":{\"pod\":\"d\"},\"dt_txt\":\"2022-03-26 18:00:00\"},{\"dt\":1648328400,\"main\":{\"temp\":286.83,\"feels_like\":285.25,\"temp_min\":286.83,\"temp_max\":286.83,\"pressure\":1005,\"sea_level\":1005,\"grnd_level\":982,\"humidity\":38,\"temp_kf\":0},\"weather\":[{\"id\":801,\"main\":\"Clouds\",\"description\":\"few clouds\",\"icon\":\"02d\"}],\"clouds\":{\"all\":21},\"wind\":{\"speed\":8.7,\"deg\":271,\"gust\":18.35},\"visibility\":10000,\"pop\":0,\"sys\":{\"pod\":\"d\"},\"dt_txt\":\"2022-03-26 21:00:00\"},{\"dt\":1648339200,\"main\":{\"temp\":281.5,\"feels_like\":277.86,\"temp_min\":281.5,\"temp_max\":281.5,\"pressure\":1009,\"sea_level\":1009,\"grnd_level\":985,\"humidity\":41,\"temp_kf\":0},\"weather\":[{\"id\":802,\"main\":\"Clouds\",\"description\":\"scattered clouds\",\"icon\":\"03n\"}],\"clouds\":{\"all\":30},\"wind\":{\"speed\":7.37,\"deg\":303,\"gust\":14.1},\"visibility\":10000,\"pop\":0,\"sys\":{\"pod\":\"n\"},\"dt_txt\":\"2022-03-27 00:00:00\"},{\"dt\":1648350000,\"main\":{\"temp\":277.36,\"feels_like\":273.57,\"temp_min\":277.36,\"temp_max\":277.36,\"pressure\":1013,\"sea_level\":1013,\"grnd_level\":989,\"humidity\":61,\"temp_kf\":0},\"weather\":[{\"id\":800,\"main\":\"Clear\",\"description\":\"clear sky\",\"icon\":\"01n\"}],\"clouds\":{\"all\":5},\"wind\":{\"speed\":4.86,\"deg\":319,\"gust\":10.79},\"visibility\":10000,\"pop\":0,\"sys\":{\"pod\":\"n\"},\"dt_txt\":\"2022-03-27 03:00:00\"},{\"dt\":1648360800,\"main\":{\"temp\":275.48,\"feels_like\":272.04,\"temp_min\":275.48,\"temp_max\":275.48,\"pressure\":1014,\"sea_level\":1014,\"grnd_level\":989,\"humidity\":66,\"temp_kf\":0},\"weather\":[{\"id\":800,\"main\":\"Clear\",\"description\":\"clear sky\",\"icon\":\"01n\"}],\"clouds\":{\"all\":8},\"wind\":{\"speed\":3.54,\"deg\":312,\"gust\":9.75},\"visibility\":10000,\"pop\":0,\"sys\":{\"pod\":\"n\"},\"dt_txt\":\"2022-03-27 06:00:00\"},{\"dt\":1648371600,\"main\":{\"temp\":274.7,\"feels_like\":270.56,\"temp_min\":274.7,\"temp_max\":274.7,\"pressure\":1015,\"sea_level\":1015,\"grnd_level\":990,\"humidity\":61,\"temp_kf\":0},\"weather\":[{\"id\":801,\"main\":\"Clouds\",\"description\":\"few clouds\",\"icon\":\"02n\"}],\"clouds\":{\"all\":13},\"wind\":{\"speed\":4.33,\"deg\":308,\"gust\":10.07},\"visibility\":10000,\"pop\":0,\"sys\":{\"pod\":\"n\"},\"dt_txt\":\"2022-03-27 09:00:00\"},{\"dt\":1648382400,\"main\":{\"temp\":274.8,\"feels_like\":270.4,\"temp_min\":274.8,\"temp_max\":274.8,\"pressure\":1017,\"sea_level\":1017,\"grnd_level\":992,\"humidity\":59,\"temp_kf\":0},\"weather\":[{\"id\":802,\"main\":\"Clouds\",\"description\":\"scattered clouds\",\"icon\":\"03d\"}],\"clouds\":{\"all\":34},\"wind\":{\"speed\":4.81,\"deg\":299,\"gust\":10.45},\"visibility\":10000,\"pop\":0,\"sys\":{\"pod\":\"d\"},\"dt_txt\":\"2022-03-27 12:00:00\"},{\"dt\":1648393200,\"main\":{\"temp\":279.47,\"feels_like\":275.76,\"temp_min\":279.47,\"temp_max\":279.47,\"pressure\":1017,\"sea_level\":1017,\"grnd_level\":993,\"humidity\":44,\"temp_kf\":0},\"weather\":[{\"id\":803,\"main\":\"Clouds\",\"description\":\"broken clouds\",\"icon\":\"04d\"}],\"clouds\":{\"all\":74},\"wind\":{\"speed\":5.89,\"deg\":295,\"gust\":9.83},\"visibility\":10000,\"pop\":0,\"sys\":{\"pod\":\"d\"},\"dt_txt\":\"2022-03-27 15:00:00\"},{\"dt\":1648404000,\"main\":{\"temp\":283.92,\"feels_like\":281.89,\"temp_min\":283.92,\"temp_max\":283.92,\"pressure\":1014,\"sea_level\":1014,\"grnd_level\":991,\"humidity\":32,\"temp_kf\":0},\"weather\":[{\"id\":802,\"main\":\"Clouds\",\"description\":\"scattered clouds\",\"icon\":\"03d\"}],\"clouds\":{\"all\":39},\"wind\":{\"speed\":7.03,\"deg\":288,\"gust\":11.57},\"visibility\":10000,\"pop\":0,\"sys\":{\"pod\":\"d\"},\"dt_txt\":\"2022-03-27 18:00:00\"},{\"dt\":1648414800,\"main\":{\"temp\":285.46,\"feels_like\":283.69,\"temp_min\":285.46,\"temp_max\":285.46,\"pressure\":1014,\"sea_level\":1014,\"grnd_level\":990,\"humidity\":36,\"temp_kf\":0},\"weather\":[{\"id\":800,\"main\":\"Clear\",\"description\":\"clear sky\",\"icon\":\"01d\"}],\"clouds\":{\"all\":0},\"wind\":{\"speed\":6.62,\"deg\":300,\"gust\":11.65},\"visibility\":10000,\"pop\":0,\"sys\":{\"pod\":\"d\"},\"dt_txt\":\"2022-03-27 21:00:00\"},{\"dt\":1648425600,\"main\":{\"temp\":280,\"feels_like\":276.81,\"temp_min\":280,\"temp_max\":280,\"pressure\":1016,\"sea_level\":1016,\"grnd_level\":992,\"humidity\":41,\"temp_kf\":0},\"weather\":[{\"id\":800,\"main\":\"Clear\",\"description\":\"clear sky\",\"icon\":\"01n\"}],\"clouds\":{\"all\":0},\"wind\":{\"speed\":4.97,\"deg\":305,\"gust\":11.61},\"visibility\":10000,\"pop\":0,\"sys\":{\"pod\":\"n\"},\"dt_txt\":\"2022-03-28 00:00:00\"},{\"dt\":1648436400,\"main\":{\"temp\":276.08,\"feels_like\":273.12,\"temp_min\":276.08,\"temp_max\":276.08,\"pressure\":1019,\"sea_level\":1019,\"grnd_level\":995,\"humidity\":59,\"temp_kf\":0},\"weather\":[{\"id\":800,\"main\":\"Clear\",\"description\":\"clear sky\",\"icon\":\"01n\"}],\"clouds\":{\"all\":0},\"wind\":{\"speed\":3.06,\"deg\":314,\"gust\":8.11},\"visibility\":10000,\"pop\":0,\"sys\":{\"pod\":\"n\"},\"dt_txt\":\"2022-03-28 03:00:00\"},{\"dt\":1648447200,\"main\":{\"temp\":274.39,\"feels_like\":271.21,\"temp_min\":274.39,\"temp_max\":274.39,\"pressure\":1021,\"sea_level\":1021,\"grnd_level\":996,\"humidity\":63,\"temp_kf\":0},\"weather\":[{\"id\":800,\"main\":\"Clear\",\"description\":\"clear sky\",\"icon\":\"01n\"}],\"clouds\":{\"all\":0},\"wind\":{\"speed\":2.92,\"deg\":292,\"gust\":8.37},\"visibility\":10000,\"pop\":0,\"sys\":{\"pod\":\"n\"},\"dt_txt\":\"2022-03-28 06:00:00\"},{\"dt\":1648458000,\"main\":{\"temp\":273.7,\"feels_like\":269.85,\"temp_min\":273.7,\"temp_max\":273.7,\"pressure\":1021,\"sea_level\":1021,\"grnd_level\":996,\"humidity\":58,\"temp_kf\":0},\"weather\":[{\"id\":800,\"main\":\"Clear\",\"description\":\"clear sky\",\"icon\":\"01n\"}],\"clouds\":{\"all\":0},\"wind\":{\"speed\":3.57,\"deg\":306,\"gust\":9.82},\"visibility\":10000,\"pop\":0,\"sys\":{\"pod\":\"n\"},\"dt_txt\":\"2022-03-28 09:00:00\"},{\"dt\":1648468800,\"main\":{\"temp\":274.04,\"feels_like\":269.81,\"temp_min\":274.04,\"temp_max\":274.04,\"pressure\":1023,\"sea_level\":1023,\"grnd_level\":998,\"humidity\":53,\"temp_kf\":0},\"weather\":[{\"id\":800,\"main\":\"Clear\",\"description\":\"clear sky\",\"icon\":\"01d\"}],\"clouds\":{\"all\":0},\"wind\":{\"speed\":4.22,\"deg\":309,\"gust\":11.19},\"visibility\":10000,\"pop\":0,\"sys\":{\"pod\":\"d\"},\"dt_txt\":\"2022-03-28 12:00:00\"}],\"city\":{\"id\":4458228,\"name\":\"Burlington\",\"coord\":{\"lat\":36.0957,\"lon\":-79.4378},\"country\":\"US\",\"population\":49963,\"timezone\":-14400,\"sunrise\":1648034218,\"sunset\":1648078293}}";

        private string geoForBurlingtonQuery = "https://api.openweathermap.org/data/2.5/weather?q=Burlington,NC,US&appid=abcd";
    }
}