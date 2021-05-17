import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http'
import { escapeIdentifier } from '@angular/compiler/src/output/abstract_emitter';
import { environment }from 'src/environments/environment';
import { Products } from '../models/products.models'
import { BehaviorSubject, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ProductsService {

  //Observable
  private observable = new BehaviorSubject<string>('');
  public observable$ = this.observable.asObservable();


  constructor(
    private http: HttpClient
  ) { }


  send(message: string){
    this.observable.next(message);
  }

  getProducts(){
    let header = new HttpHeaders()
    .set('Type-content', 'aplication/json')

    return this.http.get(environment.productos, {
      headers: header
    })
  }

  getProductById(id: number): Observable<Products>{
    return this.http.get<any>(environment.productos + id);
  }

  putProducto(product: Products): Observable<Products>{
    return this.http.put<Products>(environment.productos, product);
  }

  postProduct(request: Products){
    return this.http.post(environment.productos, request);
  }

  deleteProduct(id: number){
    return this.http.delete(environment.productos + id);
  }

}
