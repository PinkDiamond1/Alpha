import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable, Injector } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import 'rxjs/Rx';

@Injectable()
export class BaseService {

    private _apiUrl: string = 'http://auctusalphaapi.azurewebsites.net/api/';

    protected apiUrl(route: string): string {
        return this._apiUrl + route;
    }

    private http: HttpClient;

    constructor(protected injector: Injector) {
        this.http = this.injector.get(HttpClient);
    }

    protected httpGet(url: string, params: any): Observable<any> {

        let headers = this.getHttpHeaders();
        let options = { headers: headers, params: params };

        return this.http.get(url, options)
            .map(res => this.handleSuccess(res))
            .catch(error => this.handleError(error));
    }

    protected httpPost(url: string, data: any, params: HttpParams) : Observable<any> {

        let headers = this.getHttpHeaders();
        let options = { headers: headers, params: params };

        return this.http.post(url, data, options)
            .map(res => this.handleSuccess(res))
            .catch(error => this.handleError(error))
    }

    protected httpPut(url: string, data: any, params: HttpParams) : Observable<any> {

        let headers = this.getHttpHeaders();
        let options = { headers: headers, params: params };

        return this.http.put(url, data, options)
            .map(res => this.handleSuccess(res))
            .catch(error => this.handleError(error))
    }

    private handleSuccess(response) {
        return response;
    }

    private handleError(response) {
        console.log(response);

        let message = response.error && response.error.error ? response.error.error : 'SYSTEM_ERROR';
        return Observable.throw(message);
    }

    private getHttpHeaders() {
        let headers = new HttpHeaders();
        return headers;
    }
}
