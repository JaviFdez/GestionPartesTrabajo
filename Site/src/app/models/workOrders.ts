export interface IWOModelAmp {
    Id: number;
    OTCode: string;
    Description: string;
    IdProjectTask: number;
    projectName: string;
    IdUser: number;
    Username: string;
    PlannedDate: Date;
    EstimatedDuration: number;
    RemainingDuration: number;
    WorkOrderStatus: number;
    SysVersion: string;
}

export interface IWOModel {
    Id: number;
    OTCode: string;
    Description: string;
    IdProjectTask: number;
    IdUser: number;
    PlannedDate: Date;
    EstimatedDuration: number;
    RemainingDuration: number;
    WorkOrderStatus: number;
    SysVersion: string;
}