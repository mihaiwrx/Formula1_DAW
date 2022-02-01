import { TrackService } from './../services/track.service';
import { Component, OnInit } from '@angular/core';
import { Track } from '../interfaces/track.interface';
import { Router } from '@angular/router';

@Component({
  selector: 'app-calendarpage',
  templateUrl: './calendarpage.component.html',
  styleUrls: ['./calendarpage.component.css']
})
export class CalendarpageComponent implements OnInit {

  public tracks: Track[] | undefined;

  constructor(private _trackService: TrackService, private router: Router) { }

  ngOnInit(): void {
  }

  getTracks(){
    this._trackService.getAll().subscribe((items: Track[])=> {
      this.tracks = items;
    })
  }

}
