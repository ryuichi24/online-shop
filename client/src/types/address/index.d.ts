export interface Address {
    addressId?: number;
    address1: string;
    address2?: string;
    city: string;
    postCode: string;
    userId: number | null;
}