import { Schema, model } from "mongoose";
// https://mongoosejs.com/docs/typescript.html
// https://mongoosejs.com/docs/validation.html
// https://transform.tools/json-to-mongoose

const nsideSchema = new Schema(
    {
        _id: Number, // default type of PK (with _id identifier): Schema.Types.ObjectId
        location: {
            ref: "oneside", // "onside" -> 1 oldali modell neve, nem kell átírni!
            type: Number,
            required: true,
        },
        viewpointName: {
            type: String,
            required: true,
            unique: true,
            maxLength: 50,
        },
        mountain: {
            type: String,
            required: true,
            unique: true,
            maxLength: 30,
        },
        height: {
            type: Number,
            required: true,
            min: [1, "Egy kilátónak legalább 1 méter magasnak kell lennie!"],
        },
        description: {
            type: String,
            required: true,
        },
        built: {
            type: Date,
            validate: {
                validator: function (v: Date) {
                    return v <= new Date();
                },
                message: "Az aktuális dátumnál nem adhat meg későbbi dátumot a built mezőben!",
            },
        },
        imageURL: {
            type: String,
            required: true,
            maxLength: 50,
            default: "http://elit.jedlik.eu/viewpoints/no-img.jpg",
        },
    },
    { versionKey: false, id: false, toJSON: { virtuals: true }, toObject: { virtuals: true } },
);

// Mongoose also supports populating virtuals.
// Help: https://mongoosejs.com/docs/tutorials/virtuals.html#populate
// You can give the "populateField" any name you want:
// nsideSchema.virtual("populateField", {
//     ref: "oneside",
//     localField: "location",
//     foreignField: "_id",
//     justOne: true,
// });
// Use virtual for populate in controller:
// const data = await this.nsideM.find().populate("populateField", "-_id field1 field2 -field3 ...");

const nsideModel = model("nside", nsideSchema, "viewpoints");

export default nsideModel;
