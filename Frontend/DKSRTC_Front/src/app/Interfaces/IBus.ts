export interface IBus{
    busName:string,
    time: Date,
    distance: number,
    seatAvailability: SVGAnimatedNumberList,
    duration: Date,
    sequence: number,
    categoryName: string,
    typeName: string,
    perDistanceFare: number,
    baseFare: number
}