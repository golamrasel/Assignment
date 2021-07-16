export class ResponseModel {
    isError: boolean;
    message: string;
    responseException: null;
    result: any;
    statusCode: number;
    constructor() {
        this.isError = false,
        this.message = '',
        this.statusCode = 0
    }
}
