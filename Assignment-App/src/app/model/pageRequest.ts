export class PageRequestModel{
     public  pageSize: number;
    public  pageNo: number;
    public  keyword: string;

    constructor() {
         this.pageSize = 10,
        this.pageNo = 1,
        this.keyword = ''               
    }
}