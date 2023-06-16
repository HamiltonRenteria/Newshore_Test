import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ServiceService } from '../services/service.service';
import { Journeys } from '../models/Journeys';
import { Flight } from '../models/Flight';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-newshore',
  templateUrl: './newshore.component.html',
  styleUrls: ['./newshore.component.scss']
})
export class NewshoreComponent {
  formSearchJourneys: FormGroup;
  listJourneys!: Journeys[];
  listFlights!: Flight[];
  loading: boolean = false;
  seeRoutes: boolean = false;

  constructor(private fb: FormBuilder, private service: ServiceService) {
    this.formSearchJourneys = this.fb.group({
      Origin: ['', Validators.required],
      Destination: ['', Validators.required]
    });
  }

  searchJourneys(): void{
    this.loading = true;
    this.service.searchJourneys(this.formSearchJourneys.value.Origin, this.formSearchJourneys.value.Destination).subscribe((data) => {
      this.loading = false;
      if (data.length === 0) {
        Swal.fire({
          icon: 'error',
          title: 'Oops...',
          text: 'La ruta no puede ser procesada!',
        });
        this.listJourneys = data;
        this.seeRoutes = false;
      } else {
        this.listJourneys = data;
      }
    })
  }

  seeFlights(flights: Flight[]): void {
    this.loading = true;
    this.seeRoutes = true;
    this.listFlights = flights;
    this.loading = false;
  }

}
