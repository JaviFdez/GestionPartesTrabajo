export interface IUserModel {
    Name: string;
    Surname1: string;
    Surname2: string;
    IdNetUser: string;
    SysVersion: string;
    Rol: number;
}

export interface IUserModelRegister {
    UserName: string;
    Password: string;
    ConfirmPassword: string;
    PhoneNumber: string;
    Email: string;
}

export interface ILoginModel {
    Username: string;
    Password: string;
    UseRefreshTokens: boolean;
}

export interface ITokenResponseModel {
    Token: string;
    UserName: string;
    RefreshToken: string;
    UseRefreshTokens: boolean;
}