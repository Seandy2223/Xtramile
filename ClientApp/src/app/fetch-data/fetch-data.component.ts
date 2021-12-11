import { NgModule, Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { environment } from '../../environments/environment';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})

export class FetchDataComponent {
  public forecasts: WeatherForecast;
  errorMsg: string;
  countryList: string[];
  cityList: string[];

  form = new FormGroup({
    country: new FormControl('', Validators.required)
  });

  get f() {
    return this.form.controls;
  }

  changeCountry(e) {
    var formData: any = new FormData();
    formData.append("country", this.form.get('country').value);

    this.http.post<string[]>(environment.apiURL + 'weatherforecast/postCityList', formData).subscribe(result => {
      this.cityList = result;
    }, error => console.error(error));
  }

  changeCity(e) {
    var formData: any = new FormData();
    formData.append("city", this.form.get('country').value);

    this.http.post<WeatherForecast>(environment.apiURL + 'weatherforecast/postCityWeather', formData).subscribe(result => {
      if (result != null) {
        this.forecasts = result;
        this.errorMsg = null;
      }
      else {
        this.forecasts = null;
        this.errorMsg = "Something wrong with WheaterAPI. Please check later";
      }
    }, error => console.error(error));
  }

  constructor(private http: HttpClient) {
    http.get<string[]>(environment.apiURL + 'weatherforecast/getCountryList').subscribe(result => {
      this.countryList = result;
    }, error => console.error(error));
  };
}

interface WeatherForecast {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
  location: string;
  time: string;
  wind: string;
  visibility: number;
  skyconditions: string;
  dewpoint: number;
  relativehumidity: number;
  pressure: number;
}
