import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  title = 'client';
  users:any[] = [];
  constructor(private http:HttpClient){}

  ngOnInit(): void {}

  GetAll(){
    this.ResetData();
    this.http.get(environment.apiUrlUser).subscribe({
      next:(Response:any)=>this.users= Response,
      error:err=>console.log(err)
    });
  }

  GetById(data:NgForm){
    this.ResetData();
    this.http.get(environment.apiUrlUser+data.value['dataNo']).subscribe({
      next:(Response:any)=>this.users[0] = Response,
      error:err=>console.log(err)
    });
  }

  DeleteById(data:NgForm){
    this.ResetData();
    console.log(data.value['deleteNo']);
    this.http.delete(environment.apiUrlUser+data.value['deleteNo'],
    {headers:{'Content-Type': 'application/json', 'charset': 'utf-8'}}
    ).subscribe({
      next:(Response:any)=>this.users[0] = Response,
      error:err=>console.log(err)
    });
  }

  PostUser(data:NgForm){
    this.ResetData();
    console.log(data.value);
    /*//////////////////*/

    this.http
    .post<any>(environment.apiUrlAddress,{
      id:data.value["idaddress"],
      line_one:data.value["line1"],
      line_second:data.value["line2"],
      postcode:data.value["postcode"],
      country:data.value["country"],
      city:data.value["city"],
      phone:data.value["phone"],
      email:data.value["email"],
    }
    ,{headers:{'Content-Type': 'application/json; charset=utf-8'}}).subscribe({
      next:(res)=>console.log(res),
      error:err => console.log(err)
    });

    /*//////////////////*/
    this.http
    .post<any>(environment.apiUrlUser,{
      id:data.value["iduser"],
      first_name:data.value["first_name"],
      last_name:data.value["last_name"],
      id_address:data.value["idaddress"]
    }
    ,{headers:{'Content-Type': 'application/json; charset=utf-8'}}).subscribe({
      next:(res)=>console.log(res),
      error:err => console.log(err)
    });


  }

  ResetData(){
    this.users = []
  }
}
