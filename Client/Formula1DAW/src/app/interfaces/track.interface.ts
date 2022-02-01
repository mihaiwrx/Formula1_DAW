export class Track{
  id: number | undefined;
  name: string | undefined;
  length: string | undefined;
  capacity: number | undefined;
}

export class Tracks{
  item: Track;
  numar: number;
  constructor(x: Track){
      this.item = x;
      this.numar = 1;
  }
}
