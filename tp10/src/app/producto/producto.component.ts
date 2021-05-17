import { Component, OnInit } from '@angular/core';
import { AbstractControl, EmailValidator, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { nextTick } from 'process';
import { Products } from '../models/products.models'
import { ProductsService } from '../services/products.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-producto',
  templateUrl: './producto.component.html',
  styleUrls: ['./producto.component.scss']
})
export class ProductoComponent implements OnInit {

  constructor(
    private readonly fb: FormBuilder,
    private productsService: ProductsService,
    private activeRouter: ActivatedRoute,
    private router: Router
    ) { }

  form = new FormGroup({
    nombre: new FormControl('', Validators.compose(
      [Validators.minLength(2), Validators.maxLength(40), Validators.required])),
    cantidadUnidad: new FormControl('', Validators.compose(
      [Validators.minLength(2), Validators.maxLength(20), Validators.required])),
    precio: new FormControl('', Validators.compose(
      [Validators.min(0.01), Validators.max(99999), Validators.required])),
   })

  formSearch: FormGroup;

  public products: Products;

  // Para el encabezado del formulario. Si no
  //ingresamos ID, va a ser CREAR
  title: string = 'crear';
  // router: any;
  existeId: number = -1;
  visualizar: boolean = true;

  message: string;

  get nombreCtrl(): AbstractControl{
    return this.form.get('nombre');
  }
  get cantidadCtrl(): AbstractControl{
    return this.form.get('cantidadUnidad');
  }
  get precioCtrl(): AbstractControl{
    return this.form.get('precio');
  }


  ngOnInit(): void{
    // Para tomar el ID y poder editar
    let productId = this.activeRouter.snapshot.paramMap.get('id');
    if(productId != null){

      //Si ingresamos ID, cambia el título por EDITAR
      this.title = 'editar';
      this.existeId = parseInt(productId);
      this.productsService.getProductById(parseInt(productId)).subscribe(data =>
        { 
          this.nombreCtrl.setValue(data.Name),
          this.cantidadCtrl.setValue(data.QuantityPerUnit),
          this.precioCtrl.setValue(data.Price)
        })
    }
  }

  ngOnDestroy(){
    console.log('Destruido')
  }

  btnLimpiar(): void{
    if(this.nombreCtrl)
      this.nombreCtrl.setValue('');

    if(this.cantidadCtrl)
      this.cantidadCtrl.setValue('');

    if(this.precioCtrl)
      this.precioCtrl.setValue('');
  }

  btnVolver() {
    this.router.navigateByUrl('/productos');
  }

  btnGuardarProducto(): void{
    var producto = new Products();
    producto.Name = this.form.get('nombre').value;
    producto.QuantityPerUnit = this.form.get('cantidadUnidad').value;
    producto.Price = this.form.get('precio').value;
    
    if(this.title == 'crear')
    {
      //Nos subscribimos para ver si no hay ningún inconveniente
      this.productsService.postProduct(producto).subscribe((response:Products)=>{
        alert("Producto ingresado correctamente");
        this.router.navigateByUrl('/productos');
      },
        error => { alert("Error al ingresar el producto: " + error.message) }
    )}else
    {
      producto.Id = this.existeId;
      this.productsService.putProducto(producto).subscribe((response:Products)=>{
        alert("Producto editado correctamente");
        this.router.navigateByUrl('/productos');
      },
        error => { alert("Error al editar el producto: " + error.message) }
    )}
  }




  nombreVacio(): string{
    return this.nombreCtrl.value == '' ?  '' : 
              this.nombreCtrl.value.length < 2 ? 'Nombre muy corto' : "Nombre ingresado";
  }

  cantidadVacio(): string{
    return this.cantidadCtrl.value == '' ?  '' :
              this.cantidadCtrl.value.length < 2 ? 'Debe contener más caracteres' : "Nombre ingresado";
  }

  precioVacio(): string{
    return this.precioCtrl.value == '' ?  '' : 
                this.precioCtrl.value > 99999 ? 'El precio no puede superar a 99999' : 
                this.precioCtrl.value < 0.01 ? 'El precio no puede ser menor a 0.01' : 
                this.precioCtrl.value > 0.01 && 99999 ? 'Precio ingresado' : "Precio ingresado"
    // return this.precioCtrl.value == '' ?  '' : 
    //             this.precioCtrl.value > 0.01 ? 'Precio correcto' : 
    //             this.precioCtrl.value == 0 ? 'El precio no puede ser cero' : 'El precio no puede ser negativo';
  }

}
