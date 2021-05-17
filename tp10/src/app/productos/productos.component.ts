import { Component, OnInit } from '@angular/core';
import { ProductsService } from '../services/products.service';
import { Router } from '@angular/router';
import { Products } from '../models/products.models';

import { MatSnackBar } from '@angular/material/snack-bar';
import { ProductoComponent } from '../producto/producto.component';



@Component({
  selector: 'app-productos',
  templateUrl: './productos.component.html',
  styleUrls: ['./productos.component.scss']
})
export class ProductosComponent implements OnInit {


  public products: Array<any> = []
  

  constructor(
    private productsService: ProductsService,
    private router: Router,
    private snackBar:MatSnackBar
  ){
  }

  ngOnInit(): void {
    this.productsService.getProducts().subscribe((prod: any)=>{
      this.products = prod;
    })
  }

  ngOnDestroy(){
    console.log('Destruido')
  }


  editarProducto(id: number){
    this.router.navigate(['producto', id]);
  }

  eliminarProducto(id: number){
    if(confirm('Realmente desea eliminar este producto?')){
      this.productsService.deleteProduct(id).subscribe(res=>
        {
          this.openSnackBar('Item eliminado', 'Cerrar');
          // window.location.reload();
          this.ngOnInit();
        },
        // error => { alert("Se ha producido al intentar eliminar el producto: " + error.message) }
        error => { this.openSnackBar("No se puede eliminar el producto seleccionado", 'Cerrar') }
    )};
  }
  

  btnAgregarProducto() {
    this.router.navigateByUrl('/producto');
  }

  openSnackBar(message, action){
    let snackBarRef = this.snackBar.open(message, action);

    snackBarRef.afterDismissed().subscribe(() => {
      console.log('Rechazado');
    });

    snackBarRef.onAction().subscribe(() => {
      console.log('Realizado');
    });
  }

}
