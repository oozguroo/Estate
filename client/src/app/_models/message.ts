export interface Message{
    id: number;
    senderId: number;
    senderUsername: string;
    recipientId: number;
    recipientUsername: string;
    content: string;
    dateRead?: Date;
    messageSent: Date;
}