import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';

interface Product {
  id: number;
  productName: string;
  unitPrice: number;
  package: string;
  isDiscontinued: boolean;
  supplierId: number;
}

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrl: './product.component.css'
})
export class ProductComponent implements OnInit{

  public products: Product[] = [];
  public newProduct: Product = {} as Product;

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.getProducts();
  }

  getProducts() {
    this.http.get<Product[]>('https://localhost:7213/api/Product').subscribe(data => {
      this.products = data;
    }, error => { console.log("Greska pri dohvatanju podataka.", error) }
    );
  }

  onSubmit(f: NgForm) {
    this.createProduct(this.newProduct);
    console.log(f.name);
    this.resetForm(f);
  };


  createProduct(data: any) {
    return this.http.post<Product[]>('https://localhost:7213/api/Product/Create', data).subscribe(response => {
      console.log("Successfully created new product!", response);
      this.getProducts();
    }, error => {
      console.log("Error occured", error);
    })
  }

  resetForm(form: NgForm) {
    form.resetForm();
    this.newProduct = {
      id: 0,
      productName: '',
      unitPrice: 0,
      package: '',
      isDiscontinued: false,
      supplierId: 0
    };
  }



}
