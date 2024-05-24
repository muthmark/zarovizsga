// https://mongoosejs.com/docs/validation.html#built-in-validators
// https://transform.tools/json-to-mongoose

import { Schema, model } from "mongoose";

const onesideSchema = new Schema(
    {
        _id: {
            type: Number,
        },
        locationName: {
            type: String,
            required: true,
            unique: true,
            maxLength: 30,
        },
    },
    { versionKey: false, id: false, toJSON: { virtuals: true }, toObject: { virtuals: true } },
);

onesideSchema.virtual("viewpoints", {
    ref: "nside",
    localField: "_id",
    foreignField: "location",
    justOne: false,
});

const onesideModel = model("oneside", onesideSchema, "locations");

export default onesideModel;
