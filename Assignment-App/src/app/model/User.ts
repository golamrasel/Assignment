export interface User{
    email: string;
    password: any;
}
export interface UserViewModel{
  id: string,
  name: string,
  email: string;
  password: any;
  authToken: string;
}
