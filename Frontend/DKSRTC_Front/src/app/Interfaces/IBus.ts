export interface IBus{
    busId:number,
    busName:string,
    time: Date,
    distance: number,
    seatAvailability: number,
    duration: Date,
    busRouteCurrent:number,
    sequence: number,
    categoryName: string,
    typeName: string,
    perDistanceFare: number,
    baseFare: number
}