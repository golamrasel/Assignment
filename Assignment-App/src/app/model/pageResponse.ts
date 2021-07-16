export class PageResponseModel<T>{
    // public  pageSize: number;
      rows: Array<T>;
      count: number;

    constructor() {
        this.rows = new Array<T>();
        this.count = 1             
    }
}