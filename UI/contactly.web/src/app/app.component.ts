import { HttpClient} from '@angular/common/http';
import { Component, inject } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Observable } from 'rxjs';
import { Contact } from '../Models/contact.model';
import { AsyncPipe } from '@angular/common';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, AsyncPipe],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'contactly.web';
  http = inject(HttpClient);

  contacts$ = this.getContacts();

  private getContacts(): Observable<Contact[]>{
      return this.http.get<any>('https://localhost:7271/api/Contacts');
    }
    
  }
