import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { Track } from "../interfaces/track.interface";

@Injectable()
export class TrackService {
  baseUrl = "https://localhost:44374/api/track";
  constructor(private http: HttpClient){
   }

   getAll(): Observable<Track[]>{
     return this.http.get<Track[]>(this.baseUrl);
   }

   getTrack(id: number): Observable<Track>{
     return this.http.get<Track>(this.baseUrl+"/"+id);
   }

   createTrack(model: Track): Observable<any>{
     return this.http.post<Track>(this.baseUrl, model);
   }

   updateTrack(model: Track, id: number): Observable<any>{
     return this.http.put<any>(this.baseUrl+"/"+id, model);
   }

   deleteTrack(id: number): Observable<any>{
     return this.http.delete<any>(this.baseUrl+"/"+id);
   }
}
