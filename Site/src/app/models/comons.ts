export interface ICount {
    total: number;
}

export interface IPagerModel {
    totalItems: number;
    pageElemnts: number;
    totalPages: number;
    currentPage: number;
}

export interface IFiltrosProjectModel {
    ProjectCode: string;
    Description: string;
    NameCustomer: string;

}

export interface IFiltrosWOModel {
    Description: string;
    projectName: string;
    Username: string;
    WorkOrderStatus: number;
    PlannedDate1: Date;
    PlannedDate2: Date;

}